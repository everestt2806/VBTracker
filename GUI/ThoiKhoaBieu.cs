using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VBTracker.GUI
{
    public partial class ThoiKhoaBieu : Form
    {
        private List<Subject> subjects;

        public ThoiKhoaBieu()
        {
            InitializeComponent();
            InitializeTimetable();
        }

        private void InitializeTimetable()
        {
            // Tạo và điền dữ liệu vào bảng thời khóa biểu
            CreateTimetablePanel();
            FillTimetableData();
        }

        private void CreateTimetablePanel()
        {
            // Xóa hết các ColumnStyles và RowStyles hiện có
            timetablePanel.ColumnStyles.Clear();
            timetablePanel.RowStyles.Clear();

            // Thiết lập kích thước các hàng và cột
            timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            for (int i = 0; i < 7; i++) // 7 ngày trong tuần
            {
                timetablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28f));
            }

            timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // Hàng tiêu đề
            for (int i = 0; i < 16; i++) // 16 tiết
            {
                timetablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            }

            // Tạo tiêu đề cho các cột
            string[] headers = new string[]
            {
                "Tiết | Thứ\nPeriod | Day",
                "Thứ 2 | Monday\n(21/04)",
                "Thứ 3 | Tuesday\n(22/04)",
                "Thứ 4 | Wednesday\n(23/04)",
                "Thứ 5 | Thursday\n(24/04)",
                "Thứ 6 | Friday\n(25/04)",
                "Thứ 7 | Saturday\n(26/04)",
                "Chủ nhật | Sunday\n(27/04)"
            };

            for (int i = 0; i < headers.Length; i++)
            {
                Label lbl = new Label
                {
                    Text = headers[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.RoyalBlue,
                    ForeColor = Color.White,
                    Margin = new Padding(0),
                    AutoSize = false
                };
                timetablePanel.Controls.Add(lbl, i, 0);
            }

            // Tạo số tiết từ 1-16
            for (int i = 1; i <= 16; i++)
            {
                Label lbl = new Label
                {
                    Text = i.ToString(),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.RoyalBlue,
                    ForeColor = Color.White,
                    Margin = new Padding(0),
                    AutoSize = false
                };
                timetablePanel.Controls.Add(lbl, 0, i);
            }

            // Thêm các ô trống để đảm bảo lưới hoàn chỉnh
            for (int row = 1; row <= 16; row++)
            {
                for (int col = 1; col <= 7; col++)
                {
                    Panel emptyPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.White,
                        Margin = new Padding(0)
                    };
                    timetablePanel.Controls.Add(emptyPanel, col, row);
                }
            }
        }


        private void FillTimetableData()
        {
            // Xóa tất cả các control hiện có trước khi điền dữ liệu mới
            foreach (Control ctrl in timetablePanel.Controls.Cast<Control>().ToList())
            {
                if (ctrl is Panel && ctrl.BackColor != Color.RoyalBlue)
                {
                    timetablePanel.Controls.Remove(ctrl);
                }
            }

            // Tạo lớp để lưu trữ thông tin về các môn học
            subjects = new List<Subject>
                {
                    // Môn Công nghệ phần mềm (Software Engineering) - Thứ 3 (Day=2), tiết 2-3 → 2 tiết
                    new Subject(3, 2, 1, "Công nghệ phần mềm\n|Software Engineering\n(502045 - Nhóm|Groups: 4)\nPhòng|Room: F307\nGV bảo vàng", Color.LightGray),

                    // Môn Tiếng Anh 1 (English 1) - Thứ 2 (Day=1), 4 (Day=3), 6 (Day=5) tiết 4-5 → 2 tiết mỗi buổi
                    new Subject(3, 1, 4, "Tiếng Anh 1\n|English 1\n(P15H01 - Nhóm|Groups: 4014)\nPhòng|Room: E0509", Color.HotPink),
                    new Subject(3, 3, 4, "Tiếng Anh 1\n|English 1\n(P15H01 - Nhóm|Groups: 4014)\nPhòng|Room: E0509", Color.HotPink),
                    new Subject(3, 5, 4, "Tiếng Anh 1\n|English 1\n(P15H01 - Nhóm|Groups: 4014)\nPhòng|Room: E0509", Color.HotPink),

                    // Môn Nhập môn Bảo mật thông tin - Thứ 5 (Day=4), tiết 4-5 → 2 tiết
                    new Subject(3, 4, 4, "Nhập môn Bảo mật thông tin\n|Introduction to Information Security\n(502049 - Nhóm|Groups: 2)\nPhòng|Room: C309", Color.LightBlue),

                    // Môn Thực hành Công nghệ phần mềm - Thứ 3 (Day=2), tiết 7-9 → 3 tiết
                    new Subject(3, 2, 7, "Thực hành Công nghệ phần mềm\n|Thực hành Software Engineering\n(502045 - Nhóm|Groups: 4 - TĐ|Sub-group: 1)\nPhòng|Room: A607", Color.Orange),

                    // Môn Chủ nghĩa Xã hội khoa học - Thứ 2 (Day=1), Thứ 6 (Day=5) tiết 10-11 → 2 tiết mỗi buổi
                    new Subject(3, 1, 10, "Chủ nghĩa Xã hội khoa học\n|Scientific Socialism\n(306104 - Nhóm|Groups: 62)\nPhòng|Room: B511", Color.Peru),
                    new Subject(3, 5, 10, "Chủ nghĩa Xã hội khoa học\n|Scientific Socialism\n(306104 - Nhóm|Groups: 62)\nPhòng|Room: B209\nGV dạy bù", Color.Tomato),

                    // Môn Thực hành Phát triển ứng dụng web với NodeJS - Thứ 4 (Day=3), tiết 10-12 → 3 tiết
                    new Subject(3, 3, 10, "Thực hành Phát triển ứng dụng web với NodeJS\n|Thực hành Web Application Development Using NodeJS\n(502070 - Nhóm|Groups: 1 - TĐ|Sub-group: 1)\nPhòng|Room: A609", Color.Olive)
                };


            // Thêm các môn học vào bảng thời khóa biểu
            foreach (Subject subject in subjects)
            {
                Panel subjectPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = subject.Color,
                    Margin = new Padding(1),
                    Padding = new Padding(2)
                };

                Label subjectLabel = new Label
                {
                    Text = subject.Description,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Arial", 8),
                    AutoSize = false
                };

                subjectPanel.Controls.Add(subjectLabel);
                timetablePanel.Controls.Add(subjectPanel, subject.Day, subject.StartPeriod);

                // Xử lý trường hợp môn học kéo dài nhiều tiết
                if (subject.NumPeriods > 1)
                {
                    timetablePanel.SetRowSpan(subjectPanel, subject.NumPeriods);
                }

                // Đưa panel môn học lên trên cùng để không bị che khuất
                subjectPanel.BringToFront();
            }
        }

        private void BtnPreviousWeek_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã chuyển sang tuần trước", "Thông báo");
            // Thêm logic để chuyển sang tuần trước ở đây
        }

        private void BtnNextWeek_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã chuyển sang tuần sau", "Thông báo");
            // Thêm logic để chuyển sang tuần sau ở đây
        }
    }

    // Lớp lưu trữ thông tin về môn học
    public class Subject
    {
        public int NumPeriods { get; set; }  // Số tiết học
        public int Day { get; set; }         // Thứ trong tuần (1: Thứ 2, 2: Thứ 3, ..., 7: Chủ nhật)
        public int StartPeriod { get; set; } // Tiết bắt đầu
        public string Description { get; set; }  // Mô tả môn học
        public Color Color { get; set; }     // Màu nền cho môn học

        public Subject(int numPeriods, int day, int startPeriod, string description, Color color)
        {
            NumPeriods = numPeriods;
            Day = day;
            StartPeriod = startPeriod;
            Description = description;
            Color = color;
        }
    }
}