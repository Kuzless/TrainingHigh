document.addEventListener('DOMContentLoaded', function() {
    loadWorkedHoursData();
});

async function loadWorkedHoursData() {
    try {
        const response = await fetch('http://localhost:5000/api/WorkedHours');
        if (!response.ok) {
            throw new Error('Не вдалося завантажити дані');
        }
        const workedHoursRecords = await response.json();

        // Очищаем таблицу перед загрузкой новых данных
        clearTable();

        // Добавляем новые данные в таблицу
        for (const record of workedHoursRecords) {
            await populateTableRow(record.id);
        }
    } catch (error) {
        console.error('Помилка при завантаженні даних:', error);
    }
}

function clearTable() {
    const tableBody = document.querySelector('#accountingTable tbody');
    tableBody.innerHTML = ''; // Очищаем содержимое tbody
}

async function populateTableRow(id) {
    try {
        const response = await fetch(`http://localhost:5000/api/GetAll/${id}`);
        if (!response.ok) {
            throw new Error('Не вдалося завантажити інформацію для запису з ID ' + id);
        }
        const data = await response.json();
        const tableBody = document.querySelector('#accountingTable tbody');
        const row = tableBody.insertRow();
        row.insertCell(0).textContent = data.teacherInfoDTO.name;
        row.insertCell(1).textContent = data.groupDTO.name;
        row.insertCell(2).textContent = data.subjectTariffDTO.name;
        row.insertCell(3).textContent = data.subjectTariffDTO.type;
        row.insertCell(4).textContent = data.workedHoursDTO.workedHoursPlanned;
        row.insertCell(5).textContent = data.workedHoursDTO.workedHoursDone;

        // Добавляем кнопку удаления
        const deleteCell = row.insertCell(6);
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Видалити';
        deleteButton.setAttribute('data-id', id); // Здесь id - это ID записи
        deleteButton.onclick = deleteWorkedHours; // Функция, которая будет вызываться при клике
        deleteCell.appendChild(deleteButton);
    } catch (error) {
        console.error('Помилка при завантаженні даних для запису:', error);
    }
}
async function deleteWorkedHours(event) {
    if (!confirm('Видалити запис?')) return;

    const recordId = event.target.getAttribute('data-id');
    try {
        const response = await fetch(`http://localhost:5000/api/WorkedHours/${recordId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error('Помилка при видаленні запису!');
        }

        event.target.closest('tr').remove();
        alert('Запис видалено');
    } catch (error) {
        console.error('Помилка при видаленні запису:', error);
        alert('Не вдалося видалити запис: ' + error.message);
    }
}


// JavaScript для управления модальным окном
document.addEventListener('DOMContentLoaded', function () {
    const addAccBtn = document.getElementById('addAcc'); // Кнопка для открытия модального окна
    const modalAcc = document.getElementById('myModalAcc'); // Модальное окно
    const closeBtnAcc = modalAcc.querySelector('.close'); // Кнопка закрытия внутри модального окна

    // Функция для открытия модального окна
    function openModalAcc() {
        modalAcc.style.display = 'block';
        populateDropdowns();
    }

    // Функция для закрытия модального окна
    function closeModalAcc() {
        modalAcc.style.display = 'none';
    }

    // Обработчик события нажатия на кнопку "Додати інформацію"
    addAccBtn.addEventListener('click', openModalAcc);

    // Обработчик события нажатия на крестик для закрытия модального окна
    closeBtnAcc.addEventListener('click', closeModalAcc);

    // Закрытие модального окна при клике вне его области
    window.addEventListener('click', function (event) {
        if (event.target === modalAcc) {
            closeModalAcc();
        }
    });
});
async function fetchAPI(url) {
    const response = await fetch(url);
    if (!response.ok) {
        throw new Error(`Ошибка при получении данных: ${response.statusText}`);
    }
    return await response.json();
}
async function populateDropdowns() {
    try {
        const teachersData = await fetchAPI('http://localhost:5000/api/Teacher');
        populateDropdown('teacherAcc', teachersData, 'name');

        const groupsData = await fetchAPI('http://localhost:5000/api/Group');
        populateDropdown('groupAcc', groupsData, 'name');

        const subjectsData = await fetchAPI('http://localhost:5000/api/SubjectName');
        populateDropdown('subjectAcc', subjectsData, 'name');
        if (subjectsData.length > 0) {
            await updateLessonTypesDropdown(subjectsData[0].name);
        }
        // Подписываемся на изменение выбранного предмета, чтобы обновить типы занятий
        document.getElementById('subjectAcc').addEventListener('change', async (e) => {
            const selectedSubjectName = e.target.options[e.target.selectedIndex].text;
            await updateLessonTypesDropdown(selectedSubjectName);
        });

    } catch (error) {
        console.error('Ошибка при получении данных для дропдаунов:', error);
    }
}

async function updateLessonTypesDropdown(subjectName) {
    try {
        // Замените URL на актуальный путь к вашему API
        const lessonTypesData = await fetchAPI(`http://localhost:5000/api/Subject/byname/${encodeURIComponent(subjectName)}`);
        // Предполагается, что API возвращает массив объектов SubjectTariffDTO
        populateDropdown('lessonTypeAcc', lessonTypesData, 'type');
    } catch (error) {
        console.error('Ошибка при обновлении типов занятий:', error);
    }
}

function populateDropdown(dropdownId, data, textField) {
    const select = document.getElementById(dropdownId);
    select.innerHTML = ''; // Очистка существующих опций
    data.forEach(item => {
        const option = new Option(item[textField], item.id); // Предполагается, что у каждого объекта есть id
        select.add(option);
    });
}
async function saveAccountData() {
    // Объявление переменных
    const teacherId = document.getElementById('teacherAcc').value;
    const groupId = document.getElementById('groupAcc').value;
    const subjectTariffId = document.getElementById('subjectAcc').selectedOptions[0].textContent;
    const lessonTypeAccText = document.getElementById('lessonTypeAcc').selectedOptions[0].textContent;
    const hoursWorkedPlanned = document.getElementById('hoursWorkedAcc').value;
    const hoursWorkedDone = document.getElementById('hoursWorkedDoneAcc').value;

    // Проверка заполнения полей
    // Ваш код проверки

    // Получение списка SubjectTariffDTO с сервера
    let subjectTariffs = [];
    try {
        const response = await fetch('http://localhost:5000/api/Subject');
        if (!response.ok) {
            throw new Error('Не вдалося отримати список тарифів');
        }
        subjectTariffs = await response.json();
    } catch (error) {
        console.error('Помилка при отриманні списку тарифів:', error);
        alert('Помилка при отриманні списку тарифів: ' + error.message);
        return;
    }

    // Поиск нужной сущности в списке
    const selectedSubjectTariff = subjectTariffs.find(tariff =>
        tariff.name === subjectTariffId && tariff.type === lessonTypeAccText);
    console.log(selectedSubjectTariff);
    // Проверяем, заполнены ли поля
    if (!teacherId || !groupId || !subjectTariffId || !hoursWorkedPlanned || !hoursWorkedDone) {
        alert('Всі поля повинні бути заповнені!');
        return;
    }

    // Проверяем, чтобы значения количества часов были положительными числами
    if (parseFloat(hoursWorkedPlanned) <= 0 || isNaN(parseFloat(hoursWorkedPlanned)) || parseFloat(hoursWorkedDone) <= 0 || isNaN(parseFloat(hoursWorkedDone))) {
        alert('Кількість годин повинна бути додатним числом!');
        return;
    }

    const data = {
        WorkedHoursPlanned: hoursWorkedPlanned,
        WorkedHoursDone: hoursWorkedDone,
        TeacherId: teacherId,
        GroupId: groupId,
        SubjectTariffId: selectedSubjectTariff.id
    };

    try {
        // Отправляем данные на сервер через API
        const response = await fetch('http://localhost:5000/api/WorkedHours', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        });

        // Проверяем ответ сервера
        if (!response.ok) {
            throw new Error('Не вдалося зберегти дані про отработані години');
        }

        // Закрываем модальное окно и обновляем данные на странице
        document.getElementById('myModalAcc').style.display = 'none';
        await loadWorkedHoursData(); // Предполагается, что у вас есть функция для загрузки и отображения отработанных часов

        alert('Дані успішно збережено');
    } catch (error) {
        console.error('Помилка при збереженні даних про отработані години:', error);
        alert('Помилка при збереженні даних: ' + error.message);
    }
}
