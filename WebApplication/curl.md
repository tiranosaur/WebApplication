curl -X GET http://localhost:5000/user
curl -X GET http://localhost:5000/user/1
curl -X POST http://localhost:5000/user

curl -X POST http://localhost:5000/user -d  'Name=Custom&Email=custom@gmail.com' 
curl -X POST http://localhost:5000/user -d  'Name=Custom&Email=custom@gmail.com&Age=40'

curl -X PATCH http://localhost:5000/user/99 -d  'Name=Custom&Email=custom@gmail.com&Age=99'

curl -X DELETE http://localhost:5000/user/99

