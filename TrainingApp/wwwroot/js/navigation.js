document.addEventListener('DOMContentLoaded', function () {
    const groupBtn = document.getElementById('groupBtn');
    const teacherBtn = document.getElementById('teacherBtn');
    const tarifBtn = document.getElementById('tarifBtn');
    const accountingBtn = document.getElementById('accountingBtn');
    const reportBtn = document.getElementById('reportBtn');

    const groupContent = document.querySelector('.content.group');
    const teacherContent = document.querySelector('.content.teacher');
    const tariffContent = document.querySelector('.content.tariff');
    const accountingContent = document.querySelector('.content.accounting');
    const reportsContent = document.querySelector('.content.reports');

    groupBtn.addEventListener('click', function () {
        groupContent.style.display = 'block';
        teacherContent.style.display = 'none';
        tariffContent.style.display = 'none';
        accountingContent.style.display = 'none';
        reportsContent.style.display = 'none';
    });

    teacherBtn.addEventListener('click', function () {
        groupContent.style.display = 'none';
        teacherContent.style.display = 'block';
        tariffContent.style.display = 'none';
        accountingContent.style.display = 'none';
        reportsContent.style.display = 'none';
    });

    tarifBtn.addEventListener('click', function () {
        groupContent.style.display = 'none';
        teacherContent.style.display = 'none';
        tariffContent.style.display = 'block';
        accountingContent.style.display = 'none';
        reportsContent.style.display = 'none';
    });

    accountingBtn.addEventListener('click', function () {
        groupContent.style.display = 'none';
        teacherContent.style.display = 'none';
        tariffContent.style.display = 'none';
        accountingContent.style.display = 'block';
        reportsContent.style.display = 'none';
    });
});