//Дропдаун меню
document.addEventListener('DOMContentLoaded', function () {
    const dropdown = document.getElementById('groupDropdown');

    fetch('http://localhost:5000/api/group')
        .then(response => response.json())
        .then(groups => {
            groups.forEach(group => {
                const option = document.createElement('option');
                option.value = group.id;
                option.textContent = group.name;
                dropdown.appendChild(option);
            });
            dropdown.dispatchEvent(new Event('change'));
        })
        .catch(error => {
            console.error('Ошибка при получении списка групп:', error);
        });
});
// Элементы таблицы
document.addEventListener('DOMContentLoaded', function () {
    const groupDropdown = document.getElementById('groupDropdown');
    const groupTableBody = document.getElementById('groupTable').getElementsByTagName('tbody')[0];

    groupDropdown.addEventListener('change', function () {
        const groupId = this.value;
        if (!groupId || groupId === "group0") {
            groupTableBody.innerHTML = '';
            return;
        }

        fetch(`http://localhost:5000/api/student/group/${groupId}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(students => {
                groupTableBody.innerHTML = '';

                students.forEach(student => {
                    const row = groupTableBody.insertRow();

                    const cellName = row.insertCell(0);
                    cellName.textContent = student.name;

                    const cellPhone = row.insertCell(1);
                    cellPhone.textContent = student.phoneNumber;

                    const cellAddress = row.insertCell(2);
                    cellAddress.textContent = student.address;

                    const cellEmail = row.insertCell(3);
                    cellEmail.textContent = student.email;

                    const cellDelete = row.insertCell(4);
                    const deleteButton = document.createElement('button');
                    deleteButton.textContent = 'Видалити';
                    deleteButton.addEventListener('click', function () {
                        if (confirm('Видалити студента?')) {
                            // Выполнить удаление записи
                            deleteStudent(student.id, row);
                        }
                    });
                    cellDelete.appendChild(deleteButton);
                });
            })
            .catch(error => {
                console.error('Помилка при отриманні інформації про студентів:', error);
            });

    });
});

function deleteStudent(studentId, row) {
    // Отправить запрос на удаление студента с указанным ID на сервер
    fetch(`http://localhost:5000/api/student/${studentId}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            row.remove(); // Удаляем строку из таблицы только при успешном удалении
            alert('Студента видалено');
        })
        .catch(error => {
            console.error('Помилка при видаленні студента:', error);
            alert('Помилка при видаленні студента');
        });
}
// Добавление студента
function saveDataStudent() {
    // Получаем значения полей формы
    const name = document.getElementById('pib').value;
    const phone = document.getElementById('phone').value;
    const address = document.getElementById('address').value;
    const email = document.getElementById('email').value;
    const groupId = document.getElementById('groupDropdown').value;
    if (!name || !phone || !address || !email) {
        alert('Заповніть усі поля!');
        return; // Прерываем выполнение функции, чтобы форма не отправлялась
    }

    // Создаем объект студента
    const student = {
        Name: name,
        Address: address,
        PhoneNumber: phone,
        Email: email,
        GroupId: parseInt(groupId) // Преобразуем GroupId в число
    };

    // Отправляем данные на сервер
    fetch('http://localhost:5000/api/student', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            location.reload();
        })
        .then(data => {
            console.log('Данные успешно сохранены:', data);
            // Очищаем форму после успешной отправки данных
            document.getElementById('studentFormGroup').reset();
            // Закрываем модальное окно
            closeModal();
        })
        .catch(error => {
            console.error('Ошибка при сохранении данных:', error);
        });
}
document.addEventListener('DOMContentLoaded', function () {
    const addStudentBtn = document.getElementById('addStudentBtn2');
    const modal = document.getElementById('myModalGroup');
    const closeBtn = modal.querySelector('.close');

    // Функция для открытия модального окна
    function openModal() {
        modal.style.display = 'block';
    }

    // Функция для закрытия модального окна
    function closeModal() {
        modal.style.display = 'none';
    }

    // Обработчик события нажатия на кнопку "Додати Студента"
    addStudentBtn.addEventListener('click', openModal);

    // Обработчик события нажатия на кнопку закрытия модального окна
    closeBtn.addEventListener('click', closeModal);

    // Закрытие модального окна при клике вне него
    window.addEventListener('click', function (event) {
        if (event.target === modal) {
            closeModal();
        }
    });
});