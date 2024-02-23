document.addEventListener('DOMContentLoaded', function () {
    const formZvitButton = document.getElementById('formZvit');
    formZvitButton.addEventListener('click', fetchWorkedHoursAndFillTable);
});

async function fetchWorkedHoursAndFillTable() {
    try {
        const responseWorkedHours = await fetch('api/WorkedHours');
        const workedHours = await responseWorkedHours.json();

        // Загрузка содержимого zvit.html
        const responseZvitHTML = await fetch('zvit.html');
        const zvitHTMLContent = await responseZvitHTML.text();

        // Создание временного элемента для разбора HTML
        const tempDiv = document.createElement('div');
        tempDiv.innerHTML = zvitHTMLContent;

        // Получаем таблицу из загруженного HTML
        const table = tempDiv.querySelector('#data-table tbody');

        for (let i = 0; i < workedHours.length; i++) {
            const workedHour = workedHours[i];

            const responseTeacher = await fetch(`api/GetAll/${workedHour.id}`);
            const teacherInfo = await responseTeacher.json();

            // Получаем квалификацию
            const qualificationId = teacherInfo.teacherInfoDTO.qualificationId;
            const responseQualification = await fetch(`api/Qualification/${qualificationId}`);
            const qualification = await responseQualification.json();

            const row = createTableRow(i + 1, workedHour, teacherInfo, qualification);
            console.log(row);
            table.appendChild(row);
        }

        // Вставляем обновленную таблицу обратно в zvit.html
        document.body.appendChild(tempDiv);

        // Теперь, когда таблица заполнена данными, вызываем html2canvas
        html2canvas(tempDiv, { scrollY: -window.scrollY, useCORS: true }).then(canvas => {
            var imgData = canvas.toDataURL('image/png');
            var pdf = new jspdf.jsPDF({
                orientation: 'p',
                unit: 'cm',
                format: 'a4'
            });
            pdf.addImage(imgData, 'PNG', 0, 0);
            pdf.save("download.pdf");
            document.body.removeChild(tempDiv); // Удаляем контейнер после создания PDF
        });

    } catch (error) {
        console.error('Ошибка при получении данных:', error);
    }
}

function createTableRow(index, workedHour, teacherInfo, qualification) {
    const row = document.createElement('tr');

    const cellIndex = document.createElement('td');
    cellIndex.textContent = index;
    row.appendChild(cellIndex);

    const cellWorkedHourId = document.createElement('td');
    cellWorkedHourId.textContent = workedHour.teacherId;
    row.appendChild(cellWorkedHourId);

    const cellTeacherName = document.createElement('td');
    cellTeacherName.textContent = teacherInfo.teacherInfoDTO.name;
    row.appendChild(cellTeacherName);

    const sum = calculateSum(teacherInfo, qualification);
    const cellSum = document.createElement('td');
    cellSum.textContent = sum.toFixed(2);
    row.appendChild(cellSum);

    return row;
}

function calculateSum(teacherInfo, qualification) {
    const pricePerHour = teacherInfo.subjectTariffDTO.pricePerHour;
    const workedHoursDone = teacherInfo.workedHoursDTO.workedHoursDone;
    const planned = teacherInfo.workedHoursDTO.workedHoursPlanned;
    const coefficient = qualification.coefficient; // Теперь используем коэффициент напрямую из qualification
    return (pricePerHour * workedHoursDone) * coefficient * (workedHoursDone / planned);
}



// формирование пдф

function FormPdf() {
    fetch('zvit.html')
        .then(response => response.text())
        .then(html => {
            var tempDiv = document.createElement('div');
            tempDiv.innerHTML = html; // Вставка HTML в контейнер
            document.body.appendChild(tempDiv); // Добавляем контейнер в DOM
            html2canvas(tempDiv, { scrollY: -window.scrollY, useCORS: true }).then(canvas => {
                var imgData = canvas.toDataURL('image/png');
                var pdf = new jspdf.jsPDF({
                    orientation: 'p',
                    unit: 'cm',
                    format: 'a4'
                });
                pdf.addImage(imgData, 'PNG', 0, 0);
                pdf.save("download.pdf");
                document.body.removeChild(tempDiv); // Удаляем контейнер после создания PDF
            });
        })
        .catch(error => {
            console.error('Ошибка при загрузке HTML файла:', error);
        });
};
