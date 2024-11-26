// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('searchForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const query = document.getElementById('searchInput').value;
    const searchResults = document.getElementById('searchResults');
    const selectElement = document.getElementById('bookId');
    const loadingSpinner = document.getElementById('loadingSpinner');

    loadingSpinner.style.display = 'block';
    searchResults.style.display = 'none';
    selectElement.innerHTML = '<option value="">Loading...</option>';

    fetch(`/Book/Search?search=${encodeURIComponent(query)}`)
        .then(response => {
            if (!response.ok) throw new Error('Network response was not ok');
            return response.json();
        })
        .then(data => {
            console.log('Search results:', data);

            loadingSpinner.style.display = 'none';

            if (data.length > 0) {
                selectElement.innerHTML = `
                       <option value="" disabled selected style="display: none;">Select a book</option>
                       ${data.map(
                    book => `
                                <option value="${book.bookId}">
                                    ${book.title} - ${book.authorFirstName} (${book.categoryName})
                                </option>
                            `
                ).join('')}
                    `;
                searchResults.style.display = 'block';
            } else {
                selectElement.innerHTML = '<option value="">No books found</option>';
                searchResults.style.display = 'block';
            }
        })
        .catch(error => {
            loadingSpinner.style.display = 'none';
            console.error('Error fetching search results:', error);
            selectElement.innerHTML = '<option value="">Error loading books</option>';
            searchResults.style.display = 'block';
        });
});

document.getElementById('bookId').addEventListener('change', function (e) {
    const bookId = e.target.value;

    if (bookId) {
        window.location.href = `/Book/Details/${bookId}`;
    }
});

$(document).ready(function () {
    // Function to load books and populate the list
    function loadBooks() {
        $.ajax({
            url: '/api/books',
            type: 'GET',
            success: function (data) {
                $('#bookList').empty();
                data.forEach(function (book) {
                    $('#bookList').append(`
                            <li>
                                <strong>${book.title}</strong> - ${book.description || 'No Description'}
                                <br> Publisher: ${book.publisher || 'N/A'}
                                <br> Published Year: ${new Date(book.publishedYear).toLocaleDateString()}
                                <br> Total Copies: ${book.totalCopies}, Available Copies: ${book.availableCopies}
                                <br> <button onclick="editBook(${book.bookId})">Edit</button>
                                <button onclick="deleteBook(${book.bookId})">Delete</button>
                            </li>
                        `);
                });
            },
            error: function () {
                alert('Error loading books.');
            }
        });
    }

    // Create a new book
    $('#createBookForm').submit(function (e) {
        e.preventDefault();
        const bookData = {
            title: $('#title').val(),
            description: $('#description').val(),
            bookCode: $('#bookCode').val(),
            publisher: $('#publisher').val(),
            publishedYear: $('#publishedYear').val(),
            categoryId: $('#categoryId').val(),
            authorId: $('#authorId').val(),
            totalCopies: $('#totalCopies').val(),
            availableCopies: $('#availableCopies').val(),
            avatar: $('#avatar').val(),
            pdf: $('#pdf').val(),
        };
        $.ajax({
            url: '/api/books',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(bookData),
            success: function () {
                loadBooks();
                alert('Book created successfully!');
            },
            error: function () {
                alert('Error creating book.');
            }
        });
    });

    // Update an existing book
    function editBook(id) {
        // Show the form pre-filled with the book data
        $.ajax({
            url: `/api/books/${id}`,
            type: 'GET',
            success: function (book) {
                $('#editBookId').val(book.bookId);
                $('#editTitle').val(book.title);
                $('#editDescription').val(book.description);
                $('#editBookCode').val(book.bookCode);
                $('#editPublisher').val(book.publisher);
                $('#editPublishedYear').val(book.publishedYear.split('T')[0]);
                $('#editCategoryId').val(book.categoryId);
                $('#editAuthorId').val(book.authorId);
                $('#editTotalCopies').val(book.totalCopies);
                $('#editAvailableCopies').val(book.availableCopies);
                $('#editAvatar').val(book.avatar);
                $('#editPdf').val(book.pdf);

                $('#editBookForm').off('submit').on('submit', function (e) {
                    e.preventDefault();
                    const updatedBookData = {
                        bookId: id,
                        title: $('#editTitle').val(),
                        description: $('#editDescription').val(),
                        bookCode: $('#editBookCode').val(),
                        publisher: $('#editPublisher').val(),
                        publishedYear: $('#editPublishedYear').val(),
                        categoryId: $('#editCategoryId').val(),
                        authorId: $('#editAuthorId').val(),
                        totalCopies: $('#editTotalCopies').val(),
                        availableCopies: $('#editAvailableCopies').val(),
                        avatar: $('#editAvatar').val(),
                        pdf: $('#editPdf').val(),
                    };
                    $.ajax({
                        url: `/api/books/${id}`,
                        type: 'PUT',
                        contentType: 'application/json',
                        data: JSON.stringify(updatedBookData),
                        success: function () {
                            loadBooks();
                            alert('Book updated successfully!');
                        },
                        error: function () {
                            alert('Error updating book.');
                        }
                    });
                });
            },
            error: function () {
                alert('Error loading book details.');
            }
        });
    }

    // Delete a book
    function deleteBook(id) {
        if (confirm('Are you sure you want to delete this book?')) {
            $.ajax({
                url: `/api/books/${id}`,
                type: 'DELETE',
                success: function () {
                    loadBooks();
                    alert('Book deleted successfully!');
                },
                error: function () {
                    alert('Error deleting book.');
                }
            });
        }
    }

    // Load books on page load
    loadBooks();

    // Create User
    function createUser() {
        const userData = {
            username: $('#username').val(),
            email: $('#email').val(),
            password: $('#password').val(),
            role: $('#role').val()
        };

        $.ajax({
            url: '/api/users',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (response) {
                alert('User created successfully');
                // Optionally refresh the user list
            },
            error: function (error) {
                alert('Error: ' + error.responseText);
            }
        });
    }

    // Get Users
    function getUsers() {
        $.ajax({
            url: '/api/users',
            type: 'GET',
            success: function (data) {
                let usersTable = '';
                data.forEach(user => {
                    usersTable += `<tr>
                    <td>${user.username}</td>
                    <td>${user.email}</td>
                    <td><button onclick="editUser(${user.id})">Edit</button></td>
                    <td><button onclick="deleteUser(${user.id})">Delete</button></td>
                </tr>`;
                });
                $('#usersTable').html(usersTable);
            },
            error: function (error) {
                alert('Error: ' + error.responseText);
            }
        });
    }

    // Update User
    function updateUser(id) {
        const userData = {
            username: $('#username').val(),
            email: $('#email').val(),
            role: $('#role').val()
        };

        $.ajax({
            url: '/api/users/' + id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function (response) {
                alert('User updated successfully');
                // Optionally refresh the user list
            },
            error: function (error) {
                alert('Error: ' + error.responseText);
            }
        });
    }

    // Delete User
    function deleteUser(id) {
        if (confirm('Are you sure you want to delete this user?')) {
            $.ajax({
                url: '/api/users/' + id,
                type: 'DELETE',
                success: function (response) {
                    alert('User deleted successfully');
                    // Optionally refresh the user list
                },
                error: function (error) {
                    alert('Error: ' + error.responseText);
                }
            });
        }
    }


});