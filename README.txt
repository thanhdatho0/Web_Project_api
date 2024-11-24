
--Build image từ Dockerfile:
docker build -t name:tag -f Dockerfile .

--ví dụ 
docker build -t api:v1 -f Dockerfile .


--Chạy container từ image:
docker run -dp <host-port>:<container-port> --name <container-name> <your-image-name>:<tag>


--ví dụ: 
docker run -d -p 8085:8080 --name demoAPI api:v1


--xem các images trên máy
docker images

--xem container nào dag chạy 
docker ps

--Dừng và xoá container (nếu cần):
docker stop <container-name>
docker rm <container-name>