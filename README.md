# Yulgang Lost Connection
โปรแกรมนี้จัดทำขึ้นมาให้ใช้ฟรี เพื่อช่วยให้ผู้ใช้เช็คหน้าจอที่ขาดการเชื่อมต่อ แล้วแจ้งเตือนไปทางไลน์

✅ ใช้งานได้ฟรี\
✅ โปรแกรมไม่ต้องขอสิทธิ์ Adminnistrator\
✅ ไม่ดึงเมาส์ สามารถพับโปรแกรมได้\
✅ ไม่จำเป็นต้องเปิดจอเกมแสดงขึ้นมา สามารถพับจอเกมได้\
✅ แจ้งเตือนทาง Line Notify เมื่อตรวจไม่พบข้อมูลรับส่งทาง Network\
<br/>
![image](https://github.com/meawmuay/yulgang-lost-connection/assets/50597818/2e1936ca-4790-4495-abf7-b9dbf2b18727)

## เริ่มต้นใช้งาน

โปรแกรมนี้เขียนด้วยโปรแกรม Visual Studio 2022 และใช้ .NET Framework เวอร์ชั่น 6.0 เป็นอย่างต่ำ
### ดาวน์โหลด
[Yulgang Lost Connection Version 1.0.0.0](https://github.com/meawmuay/yulgang-lost-connection/releases/download/v1.0.0.0/Yulgang.Lost.Connection.1.0.0.0.rar "Yulgang Lost Connection Latest Version")

### ติดตั้ง
ตัวโปรแกรมไม่มีความจำเป็นต้องติด แต่หากคุณยังไม่ได้ลง .NET Framework เวอร์ชั่น 6.0 หรือมากกว่า ดาวน์โหลดได้จากลิงก์ด้านล่าง

[Microsoft .NET Framework 6.0.24](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.24-windows-x64-installer "Microsoft .NET Framework 6.0.24 ")

### วิธีใช้งาน
1. หลังจากโหลดแล้วให้ แตกไฟล์ออกมาเป็นโฟลเดอร์ Yulgang Lost Connection
2. เปิดไฟล์ Yulgang Lost Connection.exe เพื่อเข้าใช้งาน
3. กดโหลดข้อมูลเกม แล้วรอสักครู่ อาจจะใช้เวลามากกว่า 1 นาที
4. เลือกหน้าจอการทำงานได้จากหน้าต่างซ้ายมือ
5. หลังจากนั้นกดเริ่มทำงาน
6. โปรแกรมจะเริ่มจับรับส่งข้อมูลภายใน 30 วินาที หากพบการรับส่งข้อมูลจะข้ามไปจอถัดไปทันที
7. หากโปรแกรมไม่พบข้อมูลภายใน 30 วินาที จะแจ้งเตือนไปทาง Line Notify

### การตั้งค่า Line Notify
1. ไปที่ https://notify-bot.line.me/th/ ที่ด้านขวามือให้เลือก เข้าสู่ระบบ\
   ![image](https://github.com/meawmuay/yulgang-lost-connection/assets/50597818/628ca94b-ba4b-4b63-935b-8c5666c20668)
2. หลังจากนั้น เลือก QR Code Login แล้วใช้มือถือถ่าย QR Code จากแอปไลน์
3. เมื่อเข้าสู่ระบบแล้วให้ไปที่ https://notify-bot.line.me/my/
4. เลื่อนลงมาจะเจอปุ่มที่ชื่อว่า Generate Token หรือ สร้าง Token\
   ![image](https://github.com/meawmuay/yulgang-lost-connection/assets/50597818/1bd6333e-faad-4795-b5f5-6eae8cb9f98f)
5. ให้กรอกชื่อ Token เช่น Yulgang
6. ถัดมาให้ เลือก ไลน์ของเรา จะอยู่อันบนสุด แล้วกดสร้าง ก็จะได้ Token มา
7. ให้เอาไปใส่ที่โปรแกรม ตั้งค่า Token\
   ![image](https://github.com/meawmuay/yulgang-lost-connection/assets/50597818/e0381e52-450a-40e1-86c2-d9b4477b500b)
9. แล้วกดปุ่ม ทดสอบ หลังจากได้รับแจ้งเตือนแล้ว ให้กดปุ่มบันทึก
10. การแจ้งเตือนไลน์จะทำงานต่อหน้าจอ 1 ครั้งเท่านั้นไม่แจ้งเตือนซ้ำจนกว่าจะเริ่มโปรแกรมใหม่ เช่น มีหน้าจอ A ขาดการเชื่อต่อ ก็จะมีการแจ้งเตือนทางไลน์ แล้วหลังจากนั้นโปรแกรมวนมาเช็คว่าขาดการเชื่อมต่ออีกไหม ถ้าขาดก็จะไม่แจ้งเตือนอีกแล้วจนกว่าจะเริ่มโปรแกรมใหม่อีกครั้ง

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
