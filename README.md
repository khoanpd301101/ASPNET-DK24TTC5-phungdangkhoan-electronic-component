# XÂY DỰNG WEBSITE BÁN LINH KIỆN ĐIỆN TỬ

## 1. Thông tin sinh viên

- **Họ và tên:** Phùng Đăng Khoan
- **Mã số sinh viên:** 170124505
- **Lớp:** DK24TTC5
- **Email:** Phungdang.khoan@gmail.com
- **Số điện thoại:** 0356402462

---

## 2. Giới thiệu đề tài

Đề tài **Xây dựng website bán linh kiện điện tử** được thực hiện nhằm xây dựng một hệ thống bán hàng trực tuyến hỗ trợ người dùng tìm kiếm, xem thông tin và mua các sản phẩm linh kiện điện tử một cách thuận tiện, nhanh chóng và dễ sử dụng.

Hệ thống được phát triển để phục vụ nhu cầu kinh doanh linh kiện điện tử trên nền tảng web, đồng thời hỗ trợ công tác quản lý sản phẩm, danh mục, khách hàng, giỏ hàng và đơn hàng. Website cho phép người dùng dễ dàng tra cứu các linh kiện cần thiết như cảm biến, điện trở, tụ điện, module, vi điều khiển và nhiều sản phẩm điện tử khác.

Bên cạnh đó, hệ thống còn hỗ trợ quản trị viên trong việc cập nhật dữ liệu, theo dõi tình hình bán hàng và quản lý hoạt động của cửa hàng một cách hiệu quả.

---

## 3. Mục tiêu của đề tài

- Xây dựng website bán linh kiện điện tử có giao diện thân thiện, dễ sử dụng.
- Hỗ trợ người dùng xem danh sách sản phẩm và thông tin chi tiết sản phẩm.
- Hỗ trợ tìm kiếm sản phẩm theo tên.
- Hỗ trợ lọc sản phẩm theo danh mục.
- Xây dựng chức năng thêm sản phẩm vào giỏ hàng.
- Xây dựng chức năng đặt hàng cơ bản.
- Xây dựng chức năng quản lý sản phẩm, danh mục, khách hàng và đơn hàng cho quản trị viên.
- Kết nối cơ sở dữ liệu SQL Server để lưu trữ và quản lý thông tin.
- Vận dụng kiến thức về ASP.NET Core MVC, Entity Framework Core và SQL Server vào bài toán thực tế.

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

### 5.1. Đối với người dùng

- Xem danh sách sản phẩm
- Xem chi tiết sản phẩm
- Tìm kiếm sản phẩm theo tên
- Lọc sản phẩm theo danh mục
- Thêm sản phẩm vào giỏ hàng
- Cập nhật số lượng sản phẩm trong giỏ hàng
- Đặt hàng
- Xem thông tin đơn hàng cơ bản

### 5.2. Đối với quản trị viên

- Quản lý danh mục sản phẩm
- Quản lý thông tin sản phẩm
- Quản lý khách hàng
- Quản lý đơn hàng
- Theo dõi thông tin bán hàng cơ bản

---

## 6. Các đối tượng dữ liệu chính

Hệ thống sử dụng các bảng dữ liệu chính như:

- **Category**: lưu danh mục sản phẩm
- **Product**: lưu thông tin sản phẩm
- **Customer**: lưu thông tin khách hàng
- **Cart**: lưu thông tin giỏ hàng
- **Order**: lưu thông tin đơn hàng
- **OrderDetail**: lưu chi tiết từng sản phẩm trong đơn hàng

---

## 7. Giao diện chính của hệ thống

Một số giao diện chính của website gồm có:

- Trang chủ
- Trang danh sách sản phẩm
- Trang chi tiết sản phẩm
- Trang giỏ hàng
- Trang đặt hàng
- Trang đăng nhập/đăng ký
- Trang quản lý sản phẩm
- Trang quản lý danh mục
- Trang quản lý đơn hàng

---

## 8. Cấu trúc thư mục repository

Repository được tổ chức theo các thư mục chính như sau:

- **setup/**: chứa tài liệu hướng dẫn cài đặt, file cơ sở dữ liệu và dữ liệu mẫu
- **src/**: chứa mã nguồn chính của dự án
- **progress-report/**: chứa các báo cáo tiến độ thực hiện theo từng tuần
- **thesis/**: chứa tài liệu báo cáo đồ án, file PDF, slide và tài liệu tham khảo

---
