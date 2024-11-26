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

