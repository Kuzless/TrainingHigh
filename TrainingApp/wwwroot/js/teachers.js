// Get из бд
function populateTeachersTable(teachers) {
    const table = document.getElementById('teacherTable');
    const tbody = table.getElementsByTagName('tbody')[0];
    tbody.innerHTML = '';

    teachers.forEach(teacher => {
        const row = tbody.insertRow();
        row.insertCell(0).textContent = teacher.name;
        row.insertCell(1).textContent = teacher.phoneNumber;
        row.insertCell(2).textContent = teacher.qualification ? teacher.qualification.name : 'Не вказано';
        row.insertCell(3).textContent = teacher.address;
        row.insertCell(4).textContent = teacher.email;
        const deleteCell = row.insertCell(5);
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Видалити';
        deleteButton.setAttribute('data-id', teacher.id);
        deleteButton.onclick = deleteTeacher;
        deleteCell.appendChild(deleteButton);
    });
}
async function deleteTeacher(event) {
    if (!confirm('Видалити запис??')) return;

    const teacherId = event.target.getAttribute('data-id');
    try {
        const response = await fetch(`http://localhost:5000/api/teacher/${teacherId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error('Помилка при видаленні!');
        }

        // Удаляем строку из таблицы
        event.target.closest('tr').remove();

        alert('Запис видалено');
    } catch (error) {
        console.error('Помилка при видаленні!', error);
        alert('Не вийшло знайти запис: ' + error.message);
    }
}
document.addEventListener('DOMContentLoaded', function () {
    function loadTeachers() {
        fetch('http://localhost:5000/api/teacher') // Убедитесь, что URL соответствует вашему API
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                populateTeachersTable(data);
            })
            .catch(error => {
                console.error('Ошибка при получении данных:', error);
            });
    }
    loadTeachers();
});
// Кнопка добавить
document.addEventListener('DOMContentLoaded', function () {
    const addTeacherBtn = document.getElementById('addTeacherBtn2'); // Идентификатор кнопки для открытия модального окна с учителем
    const modal = document.getElementById('myModalTeacher'); // Идентификатор вашего модального окна с учителем
    const closeBtn = modal.querySelector('.close'); // Кнопка закрытия внутри модального окна

    // Функция для открытия модального окна
    function openModal() {
        modal.style.display = 'block';
    }

    // Функция для закрытия модального окна
    function closeModal() {
        modal.style.display = 'none';
    }

    // Обработчик события нажатия на кнопку "Додати викладача"
    addTeacherBtn.addEventListener('click', openModal);

    // Обработчик события нажатия на крестик для закрытия модального окна
    closeBtn.addEventListener('click', closeModal);

    // Закрытие модального окна при клике вне его области
    window.addEventListener('click', function (event) {
        if (event.target === modal) {
            closeModal();
        }
    });
});
// Кнопка сохранить
async function saveDataTeacher() {
    const nameField = document.getElementById('teacherName');
    const phoneField = document.getElementById('teacherPhoneNumber');
    const addressField = document.getElementById('teacherAddress');
    const emailField = document.getElementById('teacherEmail');
    if (!nameField.value || !phoneField.value || !addressField.value || !emailField.value) {
        alert('Заповніть усі поля!');
        return; // Прерываем выполнение функции, чтобы форма не отправлялась
    }
    // Собираем данные из формы
    const teacherData = {
        Name: document.getElementById('teacherName').value,
        PhoneNumber: document.getElementById('teacherPhoneNumber').value,
        Address: document.getElementById('teacherAddress').value,
        Email: document.getElementById('teacherEmail').value,
        QualificationId: parseInt(document.getElementById('teacherQual').value),
    };

    try {
        // Получаем полную информацию о квалификации
        const qualificationResponse = await fetch(`http://localhost:5000/api/qualification/${teacherData.QualificationId}`);
        if (!qualificationResponse.ok) {
            throw new Error('Ошибка при получении данных о квалификации');
        }
        const qualification = await qualificationResponse.json();

        // Добавляем объект QualificationDTO в данные учителя
        teacherData.Qualification = qualification;

        // Отправляем данные учителя на сервер
        const response = await fetch('http://localhost:5000/api/teacher', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(teacherData),
        });

        if (!response.ok) {
            throw new Error('Ошибка при отправке данных учителя');
        }
        location.reload();
    } catch (error) {
        console.error('Ошибка:', error);
        alert('Произошла ошибка при добавлении учителя');
    }
}
// Дропдаун для квалификации
document.addEventListener('DOMContentLoaded', function () {
    loadQualifications(); // Загрузка квалификаций при загрузке страницы
});

function loadQualifications() {
    fetch('http://localhost:5000/api/qualification')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch qualifications');
            }
            return response.json();
        })
        .then(qualifications => {
            const selectElement = document.getElementById('teacherQual');
            qualifications.forEach(qualification => {
                const option = document.createElement('option');
                option.value = qualification.id; // Предположим, что в объекте qualification есть поле id
                option.textContent = qualification.name; // Предположим, что в объекте qualification есть поле name
                selectElement.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error loading qualifications:', error);
        });
}