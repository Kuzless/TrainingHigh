/*
//!!Modal window
// Get the modal
var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById('addStudentBtn');

// Get the <span> element that closes the modal
var span = document.getElementsByClassName('close')[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
  modal.style.display = 'block';
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
  modal.style.display = 'none';
}

// When the user clicks on save button, save the data and close the modal
function saveData() {
  // Get the values from the input fields
  var pib = document.getElementById('pib').value;
  var phone = document.getElementById('phone').value;
  var address = document.getElementById('address').value;
  var email = document.getElementById('email').value;

  // Get the table body
  var tableBody = document.querySelector('table tbody');

  // Create a new row and cells
  var newRow = document.createElement('tr');
  var pibCell = document.createElement('td');
  var phoneCell = document.createElement('td');
  var addressCell = document.createElement('td');
 
  var emailCell = document.createElement('td');

  // Set the text content of cells
  pibCell.textContent = pib;
  phoneCell.textContent = phone;
  addressCell.textContent = address;
  emailCell.textContent = email;
  
  // Append the cells to the row
  newRow.appendChild(pibCell);
  newRow.appendChild(phoneCell);
  newRow.appendChild(addressCell);
  newRow.appendChild(emailCell);
  
  // Append the row to the table body
  tableBody.appendChild(newRow);
  
  // Clear the input fields
  document.getElementById('studentForm').reset();
  
  // Close the modal
  modal.style.display = 'none';
  }
  // When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
	if (event.target == modal) {
	modal.style.display = 'none';
	}
	}
	*/

//!!Tables display on click section 
	function teachers(){
		document.querySelector('.teacher').style.display='block';
		document.querySelector('.group').style.display='none';
		document.querySelector('.tarif').style.display='none';
		document.querySelector('.accounting').style.display='none';
		document.querySelector('.report').style.display='none';	
	}
document.getElementById('teacherBtn').onclick=teachers;

	function group(){
		document.querySelector('.group').style.display='block';
		document.querySelector('.teacher').style.display='none';
		document.querySelector('.tarif').style.display='none';
		document.querySelector('.accounting').style.display='none';
		document.querySelector('.report').style.display='none';	

	}
	document.getElementById('groupBtn').onclick=group;


	function tarif(){
		document.querySelector('.tarif').style.display='block';
		document.querySelector('.group').style.display='none';
		document.querySelector('.teacher').style.display='none';
		document.querySelector('.accounting').style.display='none';
		document.querySelector('.report').style.display='none';	
	}
	document.getElementById('tarifBtn').onclick=tarif;

	function accounting(){
		document.querySelector('.accounting').style.display='block';
		document.querySelector('.group').style.display='none';
		document.querySelector('.teacher').style.display='none';
		document.querySelector('.tarif').style.display='none';
		document.querySelector('.report').style.display='none';	
	}
	document.getElementById('accountingBtn').onclick=accounting;


	function report(){
		document.querySelector('.report').style.display='block';
		document.querySelector('.group').style.display='none';
		document.querySelector('.teacher').style.display='none';
		document.querySelector('.tarif').style.display='none';
		document.querySelector('.accounting').style.display='none';
	}
document.getElementById('reportBtn').onclick=report;
// !!End of the "Tables display on click section"







// !!Розрахунковий лист

document.getElementById('generate-report-button').addEventListener('click', function() {
	// Створення нового дропдауну для розрахункового листа
	const reportDropdown = document.createElement('div');
	reportDropdown.classList.add('report-dropdown');
 
	// Створення та стилізація кнопки для розгортання дропдауну
	const toggleButton = document.createElement('button');
	toggleButton.classList.add('toggle-report');
	toggleButton.textContent = 'Розрахунковий лист - ' + new Date().toLocaleDateString();
	reportDropdown.appendChild(toggleButton);
 
	// Створення контейнера для вмісту розрахункового листа
	const reportContent = document.createElement('div');
	reportContent.classList.add('report-content');
	// Приклад вмісту
	reportContent.innerHTML = `<p>Тут буде вміст розрахункового листа...</p>`;
	reportDropdown.appendChild(reportContent);
 
	// Додавання функціональності для розгортання/згортання дропдауну
	toggleButton.addEventListener('click', function() {
	  const content = this.nextElementSibling;
	  content.style.display = content.style.display === 'block' ? 'none' : 'block';
	});
 
	// Додавання новоствореного дропдауну на сторінку
	document.getElementById('reports-tab').appendChild(reportDropdown);
 });
 