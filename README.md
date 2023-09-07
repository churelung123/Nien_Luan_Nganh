<h1 align='center'> Branch Phát Triển Hệ Thống </h1> 

## ⚠️ **Lưu ý** ⚠️
🔴 Unity Editor Version: **2022.3.2f1** (chú ý vì nếu khác version sẽ không mở được).  

🔴 Chỉ upload 3 folders là: **Asset, Packages và ProjectSettings**, do dự án dược xây dựng trên Unity nên có nhiều file trong hệ thống vượt quá giới hạn dung lượng cho phép của Github (>100MB). Khi clone về máy và mở thì Unity sẽ tự động sinh ra các file hệ thống.

🔴 Branch: sử dụng **git switch develop** để chuyển branch phát triển và **git push -f origin develop** để hạn chế lỗi khi tải lên.

## 💪 **'Sức mạnh/Chức năng' của các folder**
- Asset:
  + Art: chứa hình ảnh dạng .png, .aseprite (pixel),...
  + Animation: chứa các chuyển động của player, enemy, UI,...
  + Scenes: quản lý các màn hình chính, màn chơi,...
  + Scripts: quản lý code.
  + UI: quản lý giao diện người dùng.
- ProjectSettings: (... đang cập nhật...)

- Package: (...đang cập nhật...)
  
## 📖 Hướng dẫn git.
Tại folder đã clone code: nhấp chuột phải -> chọn Git Bash Here


![image](https://github.com/PPThinh/Nien_Luan_Nganh/assets/138053505/46259d8e-0666-49df-be94-a7db170f5370)
- Các lệnh thường dùng:
  + **git branch**: dùng để xem các branch hiện có.
  + **git switch NameBranch**: dùng để thay đổi giữa 2 branch với nhau.
  + **git add FileName**: dùng để thêm file. VD: **git add Animation Scripts** để thêm folder Animation và Scripts hoặc **git add .** để thêm toàn bộ các thay đổi.
  + **git commit -m "Description Here"**: dùng để ghi chú hay chỉ ra những thay đổi so với bản trước.
  + **git push -f origin NameBranch**: dùng để đẩy dữ liệu từ máy lên git.
