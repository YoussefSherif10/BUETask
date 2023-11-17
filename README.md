This is a simple full-stack project using ASP.NET for the backend, Reactjs for the frontend, and Sqlite as the DB. I used Entity Framework as an ORM to deal with DB.
The project is rounded around just one endpoint with all its CRUD operations.
Additionally, the API supports filtering, sorting, Search, and Pagination.
The front-end has two main pages which are the registration form and the table to show the entries and allow editing and deletion. The reusable components are contained in a separate folder to make the app as DRY as possible. I utilized the useForm hook with the Yup package for validation.
