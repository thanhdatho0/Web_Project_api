
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

-- Tạo database
dotnet ef migrations add InitialCreate
dotnet ef database update

-- xoa migrations
dotnet ef migrations remove

-- xoa tất cả table trong postgresql
DO $$ DECLARE
    table_name TEXT;
BEGIN
    FOR table_name IN
        SELECT tablename
        FROM pg_tables
        WHERE schemaname = 'public'
    LOOP
        EXECUTE 'DROP TABLE IF EXISTS ' || quote_ident(table_name) || ' CASCADE';
    END LOOP;
END $$;
