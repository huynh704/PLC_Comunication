Tài khoản đăng nhập
   _acount = new Dictionary<string, string>()
   {
       { "admin", "admin!123" },
       { "operator", "1234!" }
   };

Các chức năng ghi giữ liệu
  0	SET  Set giá trị thanh ghi lên = 1
  1	RST  Set giá trị thanh ghi về = 0
  2	FF  Set giá trị thanh ghi về = 0 nếu giá trị đang = 1 và ngược lại
  3	BSET  Set giá trị của bit bất kì trong thanh ghi 16bit = 1
  4	BRST  Set giá trị của bit bất kì trong thanh ghi 16bit = 0
  5	MOV  Set giá trị 16bit data vào thanh ghi chỉ định
  6	BMOV  Sao chép giữ liệu theo khối
  7	FMOV  Sao thanh ghi 16bit data tới nhiều thanh ghi
  8	DBL  Chuyển đổi dữ liệu 16bit sang 32bit và ghi vào thanh ghi chỉ định
  9	SFL  Dịch 16bit dữ liệu trong thanh ghi chỉ định sang bên trái bằng số bit chỉ định
  10	SFR  Dịch 16bit dữ liệu trong thanh ghi chỉ định sang bên phải bằng số bit chỉ định
  11	INC  Tăng giá trị của thanh ghi chỉ định lên 1 giá trị
  12	DEC  Giảm giá trị của thanh ghi chỉ định xuống 1 giá trị
  13	ADD  Cộng thêm số bất kì và ghi vào thanh ghi chỉ định
  14	SUB  Trừ đi số bất kì và ghi vào thanh ghi chỉ định
  15	MUL  Nhân số bất kì và ghi vào thanh ghi chỉ định  (32bit)
  16	DIV  Chia số bất kì và ghi vào thanh ghi chỉ định (32bit) 16 bit thấp là kết quả, 16 bit cao là số dư
  17	$MOV  Ghi chuỗi kí tự chỉ định vào thanh ghi chỉ định
