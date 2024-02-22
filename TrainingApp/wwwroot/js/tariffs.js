// Get тарифы
async function loadTariffs() {
    try {
        const response = await fetch('http://localhost:5000/api/subject');
        if (!response.ok) {
            throw new Error('Не вдалося завантажити дані');
        }
        const tariffs = await response.json();
        populateTariffsTable(tariffs);
    } catch (error) {
        console.error('Помилка при завантаженні тарифів:', error);
        alert('Помилка при завантаженні даних: ' + error.message);
    }
}

function populateTariffsTable(tariffs) {
    const table = document.getElementById('tariffTable');
    const tbody = table.getElementsByTagName('tbody')[0];

    // Очищаем текущие строки
    tbody.innerHTML = '';

    // Добавляем строки в таблицу
    tariffs.forEach(tariff => {
        const row = tbody.insertRow();
        row.insertCell(0).textContent = tariff.name; // Название предмета
        row.insertCell(1).textContent = tariff.type; // Вид занятия
        row.insertCell(2).textContent = tariff.pricePerHour; // Плата за час

        // Добавляем кнопку удаления для каждого тарифа
        const deleteCell = row.insertCell(3);
        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Видалити';
        deleteButton.setAttribute('data-id', tariff.id);
        deleteButton.onclick = deleteTariff; // Функция удаления тарифа
        deleteCell.appendChild(deleteButton);
    });
}

// Get в дропдаун
function loadTariffTypes() {
    fetch('http://localhost:5000/api/SubjectType')
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch tariff types');
            }
            return response.json();
        })
        .then(tariffTypes => {
            const selectElement = document.getElementById('tariffType'); // Убедитесь, что у вас есть select с id="tariffType"
            tariffTypes.forEach(type => {
                const option = document.createElement('option');
                option.value = type.id; // Используем поле id для значения option
                option.textContent = type.type; // Используем поле type для отображаемого текста
                selectElement.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error loading tariff types:', error);
        });
}

// Вызываем функции при загрузке страницы
document.addEventListener('DOMContentLoaded', function () {
    loadTariffs();
    loadTariffTypes();

    // Здесь можете добавить другие функции загрузки, если они у вас есть
});

// Функция для удаления тарифа (аналогично deleteTeacher)
async function deleteTariff(event) {
    if (!confirm('Видалити тариф?')) return;

    const tariffId = event.target.getAttribute('data-id');
    try {
        const response = await fetch(`http://localhost:5000/api/subject/${tariffId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            throw new Error('Помилка при видаленні тарифу!');
        }

        event.target.closest('tr').remove();
        alert('Тариф видалено');
    } catch (error) {
        console.error('Помилка при видаленні тарифу:', error);
        alert('Не вдалося видалити тариф: ' + error.message);
    }
}

// Кнопка добавления тарифа
document.addEventListener('DOMContentLoaded', function () {
    const addTariffBtn = document.getElementById('addTariff'); // Идентификатор кнопки для открытия модального окна с тарифом
    const modalTariff = document.getElementById('myModalTariff'); // Идентификатор вашего модального окна с тарифом
    const closeBtnTariff = modalTariff.querySelector('.close'); // Кнопка закрытия внутри модального окна с тарифом

    // Функция для открытия модального окна с тарифом
    function openModalTariff() {
        modalTariff.style.display = 'block';
    }

    // Функция для закрытия модального окна с тарифом
    function closeModalTariff() {
        modalTariff.style.display = 'none';
    }

    // Обработчик события нажатия на кнопку "Додати тариф"
    addTariffBtn.addEventListener('click', openModalTariff);

    // Обработчик события нажатия на крестик для закрытия модального окна с тарифом
    closeBtnTariff.addEventListener('click', closeModalTariff);

    // Закрытие модального окна с тарифом при клике вне его области
    window.addEventListener('click', function (event) {
        if (event.target === modalTariff) {
            closeModalTariff();
        }
    });
});

// POST тариф
async function saveDataTariff() {
    // Получаем значения из формы
    const name = document.getElementById('tariffName').value;
    const type = document.getElementById('tariffType').selectedOptions[0].textContent; // Получаем текстовое описание типа
    const price = document.getElementById('tariffPrice').value;

    // Проверяем, заполнены ли поля
    if (!name || !type || !price) {
        alert('Всі поля повинні бути заповнені!');
        return;
    }
    if (parseFloat(price) <= 0 || isNaN(parseFloat(price))) {
        alert('Ціна повинна бути додатним числом!');
        return;
    }
    try {
        // Отправляем данные на сервер через API
        const response = await fetch(`http://localhost:5000/api/Subject/${name}/${type}/${price}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        // Проверяем ответ сервера
        if (!response.ok) {
            throw new Error('Не вдалося додати тариф');
        }

        // Закрываем модальное окно и обновляем данные на странице
        document.getElementById('myModalTariff').style.display = 'none';
        await loadTariffs(); // Предполагается, что у вас есть функция для загрузки и отображения тарифов

        alert('Тариф успішно додано');
    } catch (error) {
        console.error('Помилка при додаванні тарифу:', error);
        alert('Помилка при додаванні тарифу: ' + error.message);
    }
}

