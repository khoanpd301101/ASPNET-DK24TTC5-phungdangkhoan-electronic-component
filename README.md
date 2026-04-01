# XÂY DỰNG WEBSITE BÁN LINH KIỆN ĐIỆN TỬ

## 1. Thông tin sinh viên

- **Họ và tên:** Phùng Đăng Khoan
- **Mã số sinh viên:** 170124505
- **Lớp:** Lớp DK24TTC5

---

## 2. Giới thiệu đề tài

Đề tài **Xây dựng website bán linh kiện điện tử** được thực hiện nhằm xây dựng một hệ thống bán hàng trực tuyến hỗ trợ người dùng tìm kiếm, xem thông tin và mua các sản phẩm linh kiện điện tử một cách thuận tiện.

Website hướng đến việc hỗ trợ cửa hàng quản lý sản phẩm, danh mục, giỏ hàng, đơn hàng và thông tin khách hàng. Ngoài ra, hệ thống còn giúp người dùng dễ dàng tra cứu các linh kiện cần thiết như cảm biến, điện trở, tụ điện, module, vi điều khiển và nhiều sản phẩm điện tử khác.

---

## 3. Mục tiêu của đề tài

- Xây dựng website bán linh kiện điện tử có giao diện thân thiện, dễ sử dụng.
- Hỗ trợ người dùng xem danh sách sản phẩm và chi tiết sản phẩm.
- Hỗ trợ tìm kiếm sản phẩm theo tên.
- Hỗ trợ lọc sản phẩm theo danh mục.
- Xây dựng chức năng thêm sản phẩm vào giỏ hàng.
- Xây dựng chức năng quản lý đơn hàng cơ bản.
- Kết nối dữ liệu với SQL Server để lưu trữ và quản lý thông tin.

---

## 4. Công nghệ sử dụng

Dự án được xây dựng bằng các công nghệ sau:

- **Ngôn ngữ lập trình:** C#
- **Framework:** ASP.NET Core MVC
- **Cơ sở dữ liệu:** SQL Server
- **ORM:** Entity Framework Core
- **Giao diện:** HTML, CSS, Bootstrap, Razor View
- **Công cụ phát triển:** Visual Studio 2022

---

## 5. Chức năng chính của hệ thống

### Đối với người dùng

- Xem danh sách sản phẩm
- Xem chi tiết sản phẩm
- Tìm kiếm sản phẩm
- Lọc sản phẩm theo danh mục
- Thêm sản phẩm vào giỏ hàng
- Thêm sản phẩm vào danh sách yêu thích
- Đặt hàng

### Đối với quản trị

- Quản lý danh mục
- Quản lý sản phẩm
- Quản lý khách hàng
- Quản lý đơn hàng
- Theo dõi thông tin bán hàng

---

## 6. Các đối tượng dữ liệu chính

Hệ thống sử dụng các bảng dữ liệu chính như:

- **Category**: lưu danh mục sản phẩm
- **Product**: lưu thông tin sản phẩm
- **Customer**: lưu thông tin khách hàng
- **Cart**: lưu giỏ hàng
- **Wishlist**: lưu danh sách yêu thích
- **Order**: lưu đơn hàng
- **OrderDetail**: lưu chi tiết đơn hàng

---

## 7. Giao diện chính của hệ thống

Một số giao diện chính của website gồm có:

- Trang chủ
- Trang danh sách sản phẩm
- Trang chi tiết sản phẩm
- Trang giỏ hàng
- Trang danh sách yêu thích
- Trang đặt hàng
- Trang quản lý sản phẩm
