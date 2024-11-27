
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

INSERT INTO "TargetCustomers" ("TargetCustomerName", "Url", "Alt")
VALUES
('Nam' , 'https://yody.vn/images/menu-desktop/menu_man.png', 'Nam'),
('Nữ' , 'https://yody.vn/images/menu-desktop/menu_woman.png', 'Nữ'),
('Trẻ em', 'https://yody.vn/images/menu-desktop/menu_woman.png', 'Trẻ em')


INSERT INTO "Categories" ("Name", "TargetCustomerId")
VALUES
('Áo nam',1), ('Quần nam',1), ('Độ bộ nam',1), ('Đồ mặc trong nam',1), ('Đồ thể thao nam',1), ('Phụ kiện nam',1),
('Áo nữ',2), ('Quần nữ',2), ('Độ bộ nữ',2), ('Đồ mặc trong nữ',2), ('Đồ thể thao nữ',2), ('Đầm và chân váy nữ',2), ('Phụ kiện nữ',2),
('Áo trẻ em',3), ('Quần trẻ em',3), ('Độ bộ trẻ em',3), ('Đồ mặc trong trẻ em',3), ('Đồ thể thao trẻ em',3), ('Đầm và chân váy bé gái',3), ('Phụ kiện trẻ em',3)


INSERT INTO "Subcategories" ("SubcategoryName","Description","CategoryId")
VALUES 
('Áo polo nam', 'Áo polo dành cho nam với thiết kế thời trang, phong cách và thoải mái',1),
('Áo thun nam', 'Áo thun nam chất liệu thoáng mát, phù hợp cho các hoạt động thường ngày',1),
('Áo sơ mi nam', 'Áo sơ mi nam lịch lãm, thích hợp cho môi trường công sở và sự kiện',1),
('Áo khoác nam', 'Áo khoác nam bảo vệ khỏi thời tiết lạnh, phong cách đa dạng',1),
('Áo hoodie - Áo nỉ nam', 'Áo hoodie và áo nỉ nam, thoải mái và ấm áp cho mùa đông',1),
('Áo ba lỗ nam', 'Áo ba lỗ nam thoáng mát, phù hợp cho thể thao hoặc mặc thường ngày',1),
('Áo thun thể thao nam', 'Áo thun thể thao nam thoáng mát, phù hợp cho hoạt động thể thao',1),
('Quần jeans nam', 'Quần jeans nam phong cách, bền bỉ và thời trang',2),
('Quần âu nam', 'Quần âu nam lịch sự, phù hợp cho môi trường công sở hoặc sự kiện trang trọng',2),
('Quần kaki nam', 'Quần kaki nam thoải mái, dễ phối đồ cho các dịp khác nhau',2),
('Quần dài nam', 'Quần dài nam với thiết kế hiện đại, phù hợp cho mọi hoàn cảnh',2),
('Quần short nam', 'Quần short nam trẻ trung, thoáng mát cho mùa hè',2),
('Đồ bộ ngắn tay nam', 'Đồ bộ ngắn tay nam tiện lợi, phù hợp cho mặc nhà hoặc tập luyện',3),
('Đồ bộ dài tay nam', 'Đồ bộ dài tay nam ấm áp, thoải mái trong mùa lạnh',3),
('Áo giữ nhiệt nam', 'Áo giữ nhiệt nam bảo vệ cơ thể trong thời tiết lạnh',4),
('Quần lót nam', 'Quần lót nam chất liệu mềm mại, thoải mái suốt ngày dài',4),
('Quần thể thao nam', 'Quần thể thao nam linh hoạt, thoải mái cho các hoạt động thể thao',5),
('Bộ thể thao nam', 'Bộ thể thao nam thời trang, tiện lợi và thoáng mát',5),
('Giày nam', 'Giày nam đa dạng mẫu mã, phù hợp cho nhiều phong cách',6),
('Thắt lưng nam', 'Phụ kiện thắt lưng nam giúp tôn lên vẻ lịch lãm và phong cách',6),
('Mũ nam', 'Mũ nam bảo vệ khỏi nắng và tạo điểm nhấn thời trang',6),

('Áo polo nữ', 'Áo polo nữ phong cách, phù hợp cho các hoạt động thường ngày',7),
('Áo thun nữ', 'Áo thun nữ trẻ trung, thoải mái cho mọi hoạt động',7),
('Áo sơ mi nữ', 'Áo sơ mi nữ lịch sự, phù hợp cho công sở và các sự kiện',7),
('Áo chống nắng nữ', 'Áo chống nắng nữ bảo vệ da dưới ánh nắng mặt trời',7),
('Áo khoác nữ', 'Áo khoác nữ thời trang, giữ ấm và dễ phối đồ',7),
('Áo hoodie - Áo nỉ nữ', 'Áo hoodie và áo nỉ nữ thoải mái, ấm áp trong mùa đông',7),
('Áo len nữ', 'Áo len nữ dịu dàng, ấm áp và thời trang',7),
('Quần jeans nữ', 'Quần jeans nữ trẻ trung, phù hợp cho mọi phong cách',8),
('Quần âu nữ', 'Quần âu nữ thanh lịch, dành cho môi trường công sở hoặc sự kiện trang trọng',8),
('Quần kaki nữ', 'Quần kaki nữ thoải mái, dễ phối đồ cho nhiều hoàn cảnh',8),
('Quần dài nữ', 'Quần dài nữ thiết kế hiện đại, đa dạng kiểu dáng',8),
('Quần short nữ', 'Quần short nữ trẻ trung, ăng động cho mùa hè',8),
('Quần nỉ nữ', 'Quần nỉ nữ ấm áp, phù hợp cho mặc nhà hoặc mùa lạnh',8),
('Đồ bộ ngắn tay nữ', 'Đồ bộ ngắn tay nữ tiện lợi, phù hợp cho mặc nhà',9),
('Đồ bộ dài tay nữ', 'Đồ bộ dài tay nữ giữ ấm, thoải mái trong mùa đông',9),
('Áo giữ nhiệt nữ', 'Áo giữ nhiệt nữ giữ ấm cơ thể trong thời tiết lạnh',10),
('Áo ba lỗ - 2 dây nữ', 'Áo ba lỗ và áo 2 dây nữ thoáng mát, quyến rũ',10),
('Quần lót nữ', 'Quần lót nữ chất liệu mềm mại, thoải mái suốt cả ngày',10),
('Áo bra nữ', 'Áo bra nữ hỗ trợ tối ưu, tạo cảm giác thoải mái',10),
('Áo polo thể thao nữ', 'Áo polo thể thao nữ thời trang, thoáng mát cho các hoạt động thể thao',11),
('Bộ thể thao nữ', 'Bộ thể thao nữ tiện lợi, phù hợp cho vận động và tập luyện',11),
('Đầm nữ', 'Đầm nữ thời trang, phù hợp cho mọi dịp từ thường ngày đến tiệc tùng',12),
('Chân váy nữ', 'Chân váy nữ thanh lịch, dễ phối đồ',12),
('Giày nữ', 'Giày nữ đa dạng kiểu dáng, phù hợp với nhiều phong cách',13),
('Túi xách nữ', 'Túi xách nữ tiện dụng và thời trang',13),
('Tất nữ', 'Tất nữ chất liệu mềm mại, giữ ấm đôi chân',13),

('Áo polo trẻ em', 'Áo polo trẻ em đáng yêu, dễ thương và thoải mái', 14),
('Áo thun trẻ em', 'Áo thun trẻ em thoáng mát, phù hợp cho mọi hoạt động', 14),
('Áo sơ mi trẻ em', 'Áo sơ mi trẻ em lịch sự, đáng yêu', 14),
('Áo khoác trẻ em', 'Áo khoác trẻ em giữ ấm và bảo vệ khỏi thời tiết lạnh', 14),
('Áo hoodie - Áo nỉ trẻ em', 'Áo hoodie và áo nỉ trẻ em thoải mái, phù hợp cho mùa đông', 14),
('Áo len trẻ em', 'Áo len trẻ em mềm mại, giữ ấm tốt', 14),
('Quần jeans trẻ em', 'Quần jeans trẻ em bền bỉ, dễ vận động', 15),
('Quần kaki trẻ em', 'Quần kaki trẻ em thoải mái, dễ phối đồ', 15),
('Quần dài trẻ em', 'Quần dài trẻ em đa dạng kiểu dáng', 15),
('Quần short trẻ em', 'Quần short trẻ em thoải mái, phù hợp cho mùa hè', 15),
('Quần nỉ trẻ em', 'Quần nỉ trẻ em giữ ấm tốt, mềm mại', 15),
('Đồ bộ ngắn tay trẻ em', 'Đồ bộ ngắn tay trẻ em thoáng mát, dễ thương',16),
('Đồ bộ dài tay trẻ em', 'Đồ bộ dài tay trẻ em ấm áp, dễ vận động',16),
('Áo giữ nhiệt trẻ em', 'Áo giữ nhiệt trẻ em giữ ấm cơ thể trong mùa lạnh', 17),
('Đầm trẻ em', 'Đầm trẻ em dễ thương, phù hợp cho nhiều dịp',19),
('Chân váy trẻ em', 'Chân váy trẻ em xinh xắn, dễ phối đồ',19),
('Mũ trẻ em', 'Mũ trẻ em bảo vệ khỏi nắng và giữ ấm đầu',20),
('Tất trẻ em', 'Tất trẻ em chất liệu mềm mại, giữ ấm đôi chân',20);

INSERT INTO "Sizes" ("SizeValue")
VALUES 
('S'),
('M'),
('L'),
('XL');

INSERT INTO "Colors" ("HexaCode", "Name")
VALUES 
('#FF5733', 'Red'),
('#33FF57', 'Green'),
('#3357FF', 'Blue'),
('#FF33FF', 'Pink'),
('#000000', 'Black'),
('#FFFFFF', 'White'),
('#FFFF00', 'Yellow'),
('#FFA500', 'Orange'),
('#800080', 'Purple'),
('#A52A2A', 'Brown'),
('#00FFFF', 'Cyan'),
('#808080', 'Gray'),
('#FFC0CB', 'LightPink'),
('#FFD700', 'Gold'),
('#8B4513', 'SaddleBrown'),
('#00FF00', 'Lime'),
('#DC143C', 'Crimson'),
('#4B0082', 'Indigo'),
('#FF4500', 'OrangeRed'),
('#2E8B57', 'SeaGreen');


INSERT INTO "Materials" ("MaterialType")
VALUES 
('Cotton'),
('Polyester'),
('Leather'),
('Wool');


INSERT INTO "Providers" ("ProviderEmail", "ProviderPhone", "ProviderCompanyName")
VALUES 
('nhacungcap1@example.vn', '0912345678', 'Thời Trang Việt'),
('nhacungcap2@example.vn', '0987654321', 'May Mặc Á Châu'),
('nhacungcap3@example.vn', '0908765432', 'Đồng Phục Miền Nam'),
('nhacungcap4@example.vn', '0934567890', 'Hòa Bình Fashion');

INSERT INTO "Products" ("Name", "Price", "Cost", "Stock", "DiscountPercentage", "ProviderId", "SubcategoryId")
VALUES 
-- Áo Polo Nam
('Polo Nam Sorona Thêu', 99000, 60000, 50, 0, 1, 1),
('Áo Polo Phối Kẻ Chéo', 164000, 120000, 30, 0, 2, 1),
('Áo Polo Nam Cafe Tổ Ong Basic', 99000, 50000, 30, 0, 2, 1),
('Áo Polo Nam Cafe Chân Nẹp Chéo, Phối Màu', 209000, 170000, 28, 0, 1, 1),
('Polo Nam Cafe Dệt Tổ Ong In Ngực', 164000, 120000, 38, 0, 2, 1),

-- Áo Thun Nam
('Áo Thun Nam Cổ Tròn', 99000, 46000, 40, 0, 4, 2),
('Áo Tshirt Nam Cotton USA', 99000, 50000, 32, 0, 4, 2),
('T-Shirt Nam Relax Can Chi', 230000, 180000, 18, 0, 3, 2),
('Áo Thun Thể Thao Can Lưng', 99500, 48000, 40, 0, 3, 2),
('T-Shirt Yoguu Determination', 174500, 100000, 45, 0, 2, 2),

-- Áo Sơ Mi Nam
('Sơ Mi Dài Tay Cafe Túi Ốp Ngực', 149000, 98000, 22, 0, 3, 3),
('Áo Sơ Mi Dài Tay Nam Cafe', 149000, 98000, 28, 0, 3, 3),
('Sơ Mi Nam Cộc Tay Họa Tiết', 436000, 350000, 45, 0, 2, 3),
('Sơ Mi Tay Dài Siêu Co Dãn', 274000, 200000, 17, 0, 2, 3),
('Sơ Mi Tay Dài Nam Nano Kẻ', 289000, 210000, 26, 0, 2, 3),

-- Áo Khoác Nam
('Áo Khoác Gió Nam 3C 2 Lớp', 199000, 120000, 12, 0, 1, 4),
('Áo Phao Nam Có Mũ Siêu Nhẹ Siêu Ấm', 419000, 350000, 22, 0, 1, 4),
('Áo Khoác Gió Nam 2 Lớp Siêu Co Giãn', 730000, 600000, 16, 0, 2, 4),
('Áo Phao Nam Trần Trám', 616550, 500000, 12, 0, 2, 4),

-- Áo hoodie - Áo nỉ nam

('Áo Thu Đông Nam Kẻ In Gấu', 249000, 100000, 12, 0, 4, 5),
('Áo Thun Thu Đông Họa Tiết', 249000, 100000, 20, 0, 4, 5),
('Áo Thu Đông Nam Rip Cổ 4cm', 203000, 100000, 22, 0, 4, 5),
('Áo Hoodie Yoguu Mũ Có Cúc Bấm', 419300, 300000, 25, 0, 4, 5),

-- Áo ba lỗ nam

('Áo Ba Lỗ Nam Cơ Bản Gấu Thêu Slogan', 122550, 53000, 12, 0, 2, 6),
('Áo Ba Lỗ Nam 100% Cotton Siêu Mềm Siêu Thoáng', 99000, 35000, 33, 0, 4, 6),
('Áo Ba Lỗ Nam Rib Cổ Tròn', 104300, 39000, 20, 0, 1, 6),
('Áo Ba Lỗ Nam Cơ Bản Gấu Thêu Logo', 122550, 51000, 20, 0, 1, 6),

--  Áo thun thể thao nam

-- Quần jeans nam

('Quần Jeans Nam Coolmax Thấm Hút Siêu Tốt', 419000, 300000, 14, 0, 1, 8),
('Quần Jeans Nam Tapered Lycra Thêu Túi', 284000, 100000, 12, 0, 1, 8),
('Quần Jeans Nam Regular Cafe Đen', 419000, 312000, 22, 0, 1, 8),
('Quần Jeans Nam Slim Fit Lycra Co Giãn', 149000, 52300, 20, 0, 2, 8),
('Quần Jeans Nam Slimfit Coolmax All Season', 626000, 453000, 24, 0, 1, 8),
--

--Quần kaki nam
('Quần Kaki Nam Slimfit', 474050 , 300000, 16, 0, 4, 9),
('Quần Kaki Nam Cạp Chun Ốp Khóa Sườn', 474050, 400000, 19, 0, 4, 9),
('Quần Kaki Nam Cạp Di Động', 249500 , 159000, 22, 0, 4, 9),
('Quần Kaki Nam Jogger Cơ Bản', 149000 , 50000, 33, 0, 4, 9),
('Quần Kaki Nam Jogger Túi Hộp', 149000, 50000, 36, 0, 4, 9),


--Quần âu nam

('Quần Âu Nam Cafe Cạp Di Động', 540000, 389000, 12, 0, 3, 10),
('Quần Âu Nam Cạp Chun Ốp Dáng Côn', 569050, 379800, 15, 0, 3, 10),
('Quần Âu Nam Cafe Khoá Túi', 540550 , 400000, 22, 0, 3, 10),
('Quần Âu Nam Ngang Mắt Cá Chân', 521550, 478980, 17, 0, 3, 10),
('Quần Âu Nam Cạp Chun Ốp', 521550 , 400000, 22, 0, 3, 10),

--Quần dài nam


--Quần short nam
('Quần short thể thao nam phối cạp', 199000, 120000, 12, 0, 1, 12),
('Quần Sooc Gió Yoguu Có Túi Hộp', 258300 , 100000, 12, 0, 1, 12),
('Quần Sooc Nỉ Nam Fictional', 134500 , 50000, 15, 0, 1, 12),
('Quần Sooc Nam Cạp Chun', 149000, 63000, 33, 0, 1, 12),

--Đồ bộ ngắn tay nam

--Đồ bộ dài tay nam

--Áo giữ nhiệt nam

('Áo Thun Đông Nam Giữ Nhiệt Cổ Tròn', 199000, 120000, 12, 0, 1, 15),
('Áo Thun Đông Nam Giữ Nhiệt Cổ 3cm', 199000 , 120000, 15, 0, 1, 15),

--Quần lót nam

('Combo 2 Quần Lót Nam Boxer Phối Cạp Sọc', 179550, 91000, 24, 0, 1, 16),
('Quần Lót Nam Tam Giác Siêu Thoáng Combo2', 149000 , 40000, 12, 0, 4, 16),
('Quần lót nam boxer dệt liền mềm mại', 189050, 101000, 24, 0, 1, 16),
('Quần Lót Nam Boxer Siêu Thoáng Combo 2', 169000, 120000, 8, 0, 1, 16),


--Quần thể thao nam

--Bộ thể thao nam

--Giày nam
('Giày Lười Nam Moccasin Da Mill Đai Khóa', 692300 , 499000, 13, 0, 4, 19),

--Thắt lưng nam
('Thắt Lưng Nam Khoá Cài Mặt Xoay 04',349300 , 189000, 15, 0, 1, 21),
('Thắt Lưng Nam Khoá Lăn Mặt Kim Loại Phối Da', 499000, 300000, 13, 0, 2, 21),
('Thắt Lưng Nam Khoá Cài Kim Loại Viền Vuông', 474050 , 300000, 13, 0, 2, 21),

--Mũ nam
('Mũ Lưỡi Trai Unisex Wash Thêu Logo', 94500, 46000, 13, 0, 3, 22);


INSERT INTO "ProductSizes" ("SizeId", "ProductId")
VALUES 
(2, 2),
(1, 2),
(3, 2),
(1, 3),
(2, 3),
(3, 3),
(1, 4),
(4, 4),
(1, 5),
(4, 5),
(2, 6),
(3, 6),
(4, 6),
(1, 7),
(2, 7),
(1, 8),
(4, 8),
(2, 9),
(3, 9),
(1, 10),
(1, 11),
(2, 11),
(3, 11),
(4, 11),
(1, 12),
(2, 12),
(1, 13),
(3, 13),
(4, 13),
(1, 15),
(4, 15),
(1, 16),
(3, 16),
(1,17 ),
(2, 17),
(3, 17),
(1, 18),
(2, 18),
(4, 19),
(1, 20),
(2, 21),
(4, 21),
(1, 22),
(2, 22),
(4, 22),
(1, 23),
(2, 23),
(1, 24),
(4, 24),
(1, 25),
(4, 25),
(3, 26),
(4, 26),
(1, 27),
(2, 27),
(4, 27),
(1, 28),
(3, 28),
(1, 29),
(3, 29),
(1, 40),
(4, 40),
(3, 40),
(1, 41),
(3, 41),
(1, 42),
(3, 42),
(2, 42),
(1, 43),
(2, 43),
(4, 43),
(1, 44),
(3, 44),
(4, 44),
(3, 45),
(1, 46),
(2, 47),
(3, 47),
(4, 47),
(1, 48),
(2, 48),
(3, 48),
(4, 48),
(1, 49),
(3, 49),
(1, 50),
(2, 50),
(1,51 ),
(2, 52),
(3, 52),
(1, 53),
(2, 53),
(4, 53),
(1, 54),
(2, 54),
(1, 55),
(3, 55),
(1, 56),
(4, 56),
(1, 57),
(2, 57),
(3, 58)

INSERT INTO "ProductColors" ("ProductId", "ColorId")
VALUES 
(2, 6),
(2, 1),
(2, 5),
(3, 2),
(3, 10),
(3, 3),
(3, 5),
(4, 1),
(4, 3),
(4, 5),
(4, 14),
(5, 2),
(5, 20),
(5, 19),
(6, 7),
(6, 3),
(7, 6),
(7, 5),
(7, 1),
(8, 12),
(8, 4),
(9, 9),
(10, 1),
(10, 2);


INSERT INTO "Images" ("Url", "Alt", "ProductId", "ColorId")
VALUES 
('https://m.yodycdn.com/fit-in/filters:format(webp)/100/438/408/products/ao-polo-nam-apm6225-xng-qam6049-den-2-yody.jpg?v=1690163453110', 'áo nam', 2, 2),
('https://m.yodycdn.com/fit-in/filters:format(webp)/100/438/408/products/ao-polo-nam-apm6225-xlm-qjm6029-xah-2-yody.jpg?v=1690163453110', 'áo nam', 2, 3),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-vai-cafe-to-ong-yody-apm7125-dod-16.jpg', 'áo nam', 2, 1),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-vai-cafe-to-ong-yody-apm7125-den-11.jpg', 'áo nam', 2, 5),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-vai-cafe-to-ong-yody-apm7125-tra-6.jpg', 'áo nam', 2, 6),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-apm6443-xla-4.jpg', 'áo nam', 3, 2),
('https://m.yodycdn.com/fit-in/filters:format(webp)/100/438/408/products/ao-polo-nam-apm6225-xlm-qjm6029-xah-2-yody.jpg?v=1690163453110', 'áo nam', 3, 3),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-SAM7019-DEN%20(1).jpg', 'áo nam', 3, 5),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-ddo-25.jpg', 'áo nam', 4, 1),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-cba-22.jpg', 'áo nam', 4, 3),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-den-ao-polo-nam-2.jpg', 'áo nam', 4, 5),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-xla-17.jpg', 'áo nam', 5, 2),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-ddo-25.jpg', 'áo nam', 5, 19),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-xla-17.jpg', 'áo nam', 5, 20),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-polo-nam-yody-APM7323-XAH%20(4).jpg', 'áo nam', 6, 3),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-vag-21.jpg', 'áo nam', 6, 7),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/apm6325-ddo-25.jpg', 'áo nam', 7, 1),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/tsm5231-den-4.jpg', 'áo nam', 7, 5),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-thun-nam-yody-TSM7188-TRA%20(1).jpg', 'áo nam', 7, 6),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/stm6061-xlo-6.jpg', 'áo nam', 8, 4),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/stm6061-xam-5.jpg', 'áo nam', 8, 12),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/ao-thun-nam-yody-tsm5289-dod-1.jpg', 'áo nam', 9, 9),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/tsm5231-ddo-3.jpg', 'áo nam', 10, 1),
('https://m.yodycdn.com/fit-in/filters:format(webp)/products/stm6061-xre-6.jpg', 'áo nam', 10, 2);

