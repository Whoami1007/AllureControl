using System;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;
using System.Management;
using OfficeOpenXml;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main
{

    public partial class Main : Form
    {

        enum Allures
        {
            Hallop,
            Run,
            Step
        }

        private bool isDataModified = false;
        private string currentFilePath = null;

        private double CorrectionCoeff = 1.0;

        bool _continue = false;

        int currentDist = 100;
        List<string> ids = new List<string>();
        SerialPort ser = new SerialPort();

        double[] step_150 = new double[]
        {
            67, 68, 69,
            70, 71, 72, 73,
            74, 75, 76, 77,
            78, 79, 80, 81,
            82, 83, 84, 85,
            86, 87, 88, 89,
            90, 91, 92, 93,
            94, 95, 96, 97
        };

        double[] step_100 = new double[]
        {
            44.67, 45.33, 64.00,
            46.67, 47.33, 48.00, 48.67,
            49.33, 50.00, 50.67, 51.33,
            52.00, 52.67, 53.33, 54.00,
            54.67, 55.33, 56.00, 56.67,
            57.33, 58.00, 58.67, 59.33,
            60.00, 60.67, 61.33, 62.00,
            62.67, 63.33, 64.00, 64.67
        };
        double[] run_150 = new double[]
        {
            77.5,
            76.25,
            75,
            73.75,
            72.5,
            71.25,
            70,
            68.75,
            67.5,
            66.25,
            65,
            63.75,
            62.5,
            61.25,
            60,
            58.75,
            57.5,
            56.25,
            55,
            53.75,
            52.5,
            51.25,
            50,
            48.75,
            47.5,
            46.25,
            45,
            43.75,
            42.5,
            41.25,
            40
        };
        double[] run_100 = new double[]
        {
            51.67,
            50.83,
            50.00,
            49.17,
            48.33,
            47.50,
            46.67,
            45.83,
            45.00,
            44.17,
            43.33,
            42.50,
            41.67,
            40.83,
            40.00,
            39.17,
            38.33,
            37.50,
            36.67,
            35.83,
            35.00,
            34.17,
            33.33,
            32.50,
            31.67,
            30.83,
            30.00,
            29.17,
            28.33,
            27.50,
            26.67
        };
        double[] hallop_150 = new double[]
        {
            33.8,
            33.6,
            33.5,
            33.3,
            33.2,
            33.0,
            32.9,
            32.7,
            32.6,
            32.4,
            32.3,
            32.1,
            32.0,
            31.8,
            31.7,
            31.5,
            31.4,
            31.2,
            31.1,
            30.9,
            30.8,
            30.6,
            30.5,
            30.3,
            30.2,
            30.0,
            29.3,
            28.5,
            27.9,
            27.0,
            26.3
        };
        double[] hallop_100 = new double[]
        {
            22.53,
            22.40,
            22.33,
            22.20,
            22.13,
            22.00,
            21.93,
            21.80,
            21.73,
            21.60,
            21.53,
            21.40,
            21.33,
            21.20,
            21.13,
            21.00,
            20.93,
            20.80,
            20.73,
            20.60,
            20.53,
            20.40,
            20.33,
            20.20,
            20.13,
            20.00,
            19.53,
            19.00,
            18.60,
            18.00,
            17.53
        };
        public Main()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3"); // 2 for arrival, 3 for removal
            InitializeComponent();
            ExcelPackage.License.SetNonCommercialOrganization("АРКТ НЦКТ");
            watcher.Query = query;
            watcher.EventArrived += new EventArrivedEventHandler(Watcher_EventArrived);
            watcher.Start();

            ser.BaudRate = 9600;
            FillActiveComPorts(comboBox1);
            ser.DataReceived += new SerialDataReceivedEventHandler(DataRecivedHandler);
            ser.PortName = comboBox1.SelectedItem.ToString();
        }

        private void stop()
        {
            ser.Close();
            try
            {
                panel2.BackColor = Color.FromArgb(255, 240, 240, 240);
                panel3.BackColor = Color.FromArgb(255, 240, 240, 240);
                _continue = false; // Остановка приёма
                startAllButton.Text = "Начать счёт времени (для выбранного участника)";
                panel2.Enabled = false;
                panel3.Enabled = false;
                comboBox1.Enabled = true;
            }
            catch { }

            return;
        }
        private void startAllButton_Click(object sender, EventArgs e)
        {
            if (_continue)
            {
                stop();
            }
            else
            {
                try
                {
                    ser.Open();
                    _continue = true; // Начало приёма

                    startAllButton.Text = "Стоп";
                    panel2.Enabled = true;
                    panel3.Enabled = true;
                    comboBox1.Enabled = false;
                    ser.WriteLine("1");
                    ser.WriteLine("2");
                    panel2.BackColor = Color.LimeGreen;
                    panel3.BackColor = Color.LimeGreen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }
        private void FillActiveComPorts(System.Windows.Forms.ComboBox comboBox)
        {
            try
            {
                // Очищаем ComboBox перед заполнением
                comboBox.Items.Clear();

                // Получаем список доступных COM-портов
                string[] ports = SerialPort.GetPortNames();

                // Если порты найдены, добавляем их в ComboBox
                if (ports.Length > 0)
                {
                    comboBox.Items.AddRange(ports);
                    comboBox.SelectedIndex = 0; // Выбираем первый порт по умолчанию
                }
                else
                {
                    comboBox.Items.Add("COM-порты не найдены");
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение
                comboBox.Items.Clear();
                comboBox.Items.Add($"Ошибка: {ex.Message}");
                comboBox.SelectedIndex = 0;
            }
        }
        public void DataRecivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string message = sp.ReadLine();

                if (message[0] == '8')
                {
                    panel2.BackColor = Color.FromArgb(255, 240, 116, 39);
                }
                if (message[0] == '9')
                {
                    panel3.BackColor = Color.FromArgb(255, 240, 116, 39);
                }

                if (message[0] == '3')
                {

                    int interval = 0;

                    if (ser.IsOpen)
                    {
                        ser.WriteLine("1");
                        ser.WriteLine("2");
                    }
                    interval = Math.Abs(int.Parse(message.Split(':')[1]));
                    double time_interval = double.Parse(interval.ToString()) * CorrectionCoeff;
                    string msg = string.Format("{0:d2},{1:d2}", (int)TimeSpan.FromMilliseconds(Math.Abs(time_interval)).TotalSeconds, (int)TimeSpan.FromMilliseconds(Math.Abs(time_interval)).Milliseconds / 10);

                    DialogResult dialogResult = MessageBox.Show(msg, "Время", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        stop();
                        if (dataGridView1.SelectedRows.Count <= 0)
                        {
                            MessageBox.Show("Не выбрано строк");
                            return;
                        }
                        upd_Time(TimeSpan.FromMilliseconds(Math.Abs(time_interval)));
                        update_penalties();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

            }
            catch { }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int? number = TryParseToInteger(textBox2.Text);
            foreach (ToolStripMenuItem item in HallopToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    add_member(Allures.Hallop, int.Parse(item.Text));
                }
            }
            foreach (ToolStripMenuItem item in RunToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    add_member(Allures.Run, int.Parse(item.Text));
                }
            }
            foreach (ToolStripMenuItem item in StepToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    add_member(Allures.Step, int.Parse(item.Text));
                }
            }


            /*if (number == TryParseToInteger(textBox2.Text))
            {
                MessageBox.Show("Список аллюров для участника пуст.\nВыберите \"Используемые аллюры\" в панели сверху (минимум 1)", "Внимание!");
            }*/

        }

        private void add_member(Allures Allure_Type, int? number)
        {

            int? id = TryParseToInteger(idTextBox.Text);
            string name = nameTextBox.Text;
            string? type;
            switch (Allure_Type)
            {
                case Allures.Hallop:
                    type = "Галоп";
                    break;
                case Allures.Run:
                    type = "Рысь";
                    break;
                case Allures.Step:
                    type = "Шаг";
                    break;
                default:
                    type = null;
                    break;
            }

            string hname = textBox1.Text;

            if (id == null || name == string.Empty || type == string.Empty || textBox2.Text == null)
            {
                MessageBox.Show("Введено некорректное значение");
                return;
            }

            string numb = textBox2.Text + "." + number.ToString();
            if (ids.Contains(numb))
            {
                //MessageBox.Show("Данный старт уже в списке");
                return;
            }
            ids.Add(numb);

            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            dataGridView1.Rows.Add(numb, id, name, hname, type, "", false, false, cell, 0, 0, currentDist);
        }
        public int? TryParseToInteger(string input)
        {
            if (int.TryParse(input, out int result))
                return result;
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ids.RemoveAt(dataGridView1.SelectedRows[0].Index);
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null) { return; }
            ser.PortName = comboBox1.SelectedItem.ToString();
        }

        private void upd_Time(TimeSpan time)
        {
            TimeSpan DistanceTime = time;
            string formated = String.Format("{0:d2},{1:d2}", (int)DistanceTime.TotalSeconds, DistanceTime.Milliseconds / 10);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1[5, dataGridView1.SelectedRows[0].Index].Value = formated;
                if (dataGridView1.SelectedRows[0].Index + 1 < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[dataGridView1.SelectedRows[0].Index + 1].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("Проблема в функции пересчета времени");
            }
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XLSX файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите Exel файл для импорта";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        LoadCsvToDataGridView(dataGridView1, openFileDialog.FileName);
                        MessageBox.Show("Данные успешно загружены!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveDialog()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XLSX файлы (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Сохранить данные в Exel файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    try
                    {
                        ExportToExcel(dataGridView1, saveFileDialog.FileName);
                        MessageBox.Show("Данные успешно сохранены!", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении файла:\n{ex.Message}", "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LoadCsvToDataGridView(DataGridView dgv, string filePath)
        {
            // Очищаем существующие данные
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            ImportFromExcel(dgv, filePath);
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show("Данные успешно очищены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ser.PortName = comboBox1.SelectedItem.ToString();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (currentDist == 150)
            {
                toolStripMenuItem3.Checked = true;
                toolStripMenuItem4.Checked = false;
                currentDist = 100;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (currentDist == 100)
            {
                toolStripMenuItem3.Checked = false;
                toolStripMenuItem4.Checked = true;
                currentDist = 150;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FillActiveComPorts(comboBox1);
        }
        private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            /// Not working for some reason
            FillActiveComPorts(comboBox1);
            ManagementBaseObject newEvent = e.NewEvent;
            string eventType = newEvent.GetPropertyValue("EventType").ToString();
        }

        private void галопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem allure = (ToolStripMenuItem)sender;
            allure.Checked = !allure.Checked;
        }
        private void SelectAllureFrom_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem number = (ToolStripMenuItem)sender;
            switch (number.Text)
            {
                case "1":
                    toolStripMenuItem5.Checked = false;
                    toolStripMenuItem8.Checked = false;
                    toolStripMenuItem11.Checked = false;
                    break;
                case "2":
                    toolStripMenuItem6.Checked = false;
                    toolStripMenuItem9.Checked = false;
                    toolStripMenuItem12.Checked = false;
                    break;
                case "3":
                    toolStripMenuItem7.Checked = false;
                    toolStripMenuItem10.Checked = false;
                    toolStripMenuItem13.Checked = false;
                    break;
            }
            number.Checked = !number.Checked;

            //Update all statuses

            ToolStripMenuItem item = (ToolStripMenuItem)number.OwnerItem;
            if (number.Checked)
            {
                item.Checked = true;
            }
            else
            {
                item.Checked = false;
            }
        }

        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem11.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem12.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem13.Checked = false;
            HallopToolStripMenuItem.Checked = false;
            RunToolStripMenuItem.Checked = false;
            StepToolStripMenuItem.Checked = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ser.WriteLine("1");
                ser.WriteLine("2");
                stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Порт недоступен");
            }
        }

        private int Penalties_for_zastup(DataGridViewRow row)
        {
            switch (row.Cells["Zastyp"].Value.ToString())
            {
                case "1":
                    return 3;
                case "2":
                    return 6;
                case "3":
                    return 10;
                case "4+":
                    return -1;
                default:
                    return 0;
            }
        }

        private int Find_in_table(string time, Allures allure, int distance)
        {
            double t = TimeStrToInt(time);
            double[] array;
            bool is_100 = distance == 100 ? true : false;
            bool is_step = false;
            int current_bonus = 0;
            switch (allure)
            {
                case Allures.Step:
                    array = is_100 ? step_100 : step_150;
                    is_step = true;
                    break;
                case Allures.Run:
                    array = is_100 ? run_100 : run_150;
                    break;
                case Allures.Hallop:
                    array = is_100 ? hallop_100 : hallop_150;
                    break;
                default:
                    return -1;
            }
            Array.Reverse(array);
            if (is_step)
            {
                foreach (double Etalon in array)
                {
                    if (Etalon > t)
                    {
                        current_bonus++;
                    }
                }
            }
            else
            {
                foreach (double Etalon in array)
                {
                    if (Etalon < t)
                    {
                        current_bonus++;
                    }
                }
            }
            if (current_bonus == 0) { current_bonus++; }
            return current_bonus - 1;
        }

        private double TimeStrToInt(string time)
        {
            //time = time.Replace(',', '.');
            return double.Parse(time);
        }

        private Allures AllureType(DataGridViewRow row)
        {
            string t = row.Cells["type"].Value.ToString();
            if (t.Equals("Галоп"))
            {
                return Allures.Hallop;
            }
            if (t.Equals("Шаг"))
            {
                return Allures.Step;
            }
            else
            {
                return Allures.Run;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update_penalties();
        }

        private void update_penalties()
        {
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {


                row.Cells["bonus"].Value = 30;
                row.Cells["penalty"].Value = 0;
                /*
                 * 1 заступ - 3 балла
                 * 2 заступа - 6 баллов
                 * 3 заступа - 10 баллов
                 * */
                if (row.Cells["time"].Value is null)
                {
                    continue;
                }
                if (row.Cells["time"].Value == string.Empty)
                {
                    continue;
                }
                if ((bool)row.Cells["RZ_Exit"].Value == true || (bool)row.Cells["Sboy"].Value == true || Penalties_for_zastup(row) < 0)
                {
                    row.Cells["bonus"].Value = 0;
                    row.Cells["penalty"].Value = 30;
                }
                else
                {
                    string time = row.Cells["time"].Value.ToString();
                    string distance = row.Cells["distance"].Value.ToString();
                    int bonus = Find_in_table(time, AllureType(row), int.Parse(distance));
                    row.Cells["bonus"].Value = bonus;
                    row.Cells["penalty"].Value = 30 - bonus + Penalties_for_zastup(row);
                }
                isDataModified = true;
            }
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

        public bool ExportToExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Проверяем, есть ли данные в DataGridView
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                // Создаем папку, если она не существует
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Используем EPPlus для создания Excel файла
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    // Создаем лист
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data");

                    int rowIndex = 1;
                    int colIndex = 1;

                    // Записываем заголовки
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible) // Только видимые колонки
                        {
                            worksheet.Cells[rowIndex, colIndex].Value = column.HeaderText;
                            colIndex++;
                        }
                    }

                    // Форматируем заголовки
                    using (var headerRange = worksheet.Cells[1, 1, 1, colIndex - 1])
                    {
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                        headerRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    // Записываем данные
                    rowIndex = 2;
                    foreach (DataGridViewRow gridRow in dataGridView.Rows)
                    {
                        if (!gridRow.IsNewRow) // Пропускаем новую строку для добавления
                        {
                            colIndex = 1;
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {
                                if (column.Visible)
                                {
                                    var cell = gridRow.Cells[column.Index];
                                    object cellValue;

                                    // Обрабатываем CheckBox ячейки
                                    if (cell is DataGridViewCheckBoxCell checkBoxCell)
                                    {
                                        // Сохраняем значение как True/False
                                        cellValue = checkBoxCell.Value?.ToString() ?? "False";
                                        if (cellValue == "True") cellValue = "Да";
                                        if (cellValue == "False") cellValue = "Нет";
                                    }
                                    // Обрабатываем ComboBox ячейки - просто берем значение
                                    else if (cell is DataGridViewComboBoxCell comboBoxCell)
                                    {
                                        cellValue = comboBoxCell.Value?.ToString() ?? "0";
                                    }
                                    else
                                    {
                                        cellValue = cell.Value?.ToString() ?? "";
                                    }

                                    worksheet.Cells[rowIndex, colIndex].Value = cellValue;
                                    colIndex++;
                                }
                            }
                            rowIndex++;
                        }
                    }

                    // Автоподбор ширины колонок
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Сохраняем файл
                    excelPackage.SaveAs(new FileInfo(filePath));
                    isDataModified = false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ImportFromExcel(DataGridView dataGridView, string filePath)
        {
            try
            {
                // Проверяем существование файла
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Файл не найден", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Используем EPPlus для чтения Excel файла
                using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(filePath)))
                {
                    // Получаем первый лист
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                    if (worksheet == null || worksheet.Dimension == null)
                    {
                        MessageBox.Show("Файл не содержит данных", "Информация",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    // Очищаем существующие данные в DataGridView
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Варианты для ComboBox
                    string[] comboBoxItems = { "0", "1", "2", "3", "4+" };
                    string[] col_names = { "Number", "id", "name", "HName", "type", "time", "RZ_Exit", "Sboy", "Zastyp", "bonus", "penalty", "distance" };

                    // Создаем колонки на основе первой строки (заголовков)
                    for (int col = 1; col <= colCount; col++)
                    {
                        string header = worksheet.Cells[1, col].Value?.ToString() ?? $"Column {col}";

                        // Проверяем, является ли эта колонка колонкой "Заступы" (индекс 8, если считать с 0)
                        bool isComboBoxColumn = (col - 1 == 8) || header == "Заступы";

                        // Анализируем данные в колонке, чтобы определить тип
                        bool isBooleanColumn = IsColumnBoolean(worksheet, col, rowCount);

                        if (isComboBoxColumn)
                        {
                            // Создаем колонку с ComboBox
                            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                            comboBoxColumn.HeaderText = header;
                            comboBoxColumn.Name = col_names[col - 1];

                            // Добавляем варианты выбора
                            comboBoxColumn.Items.AddRange(comboBoxItems);

                            dataGridView.Columns.Add(comboBoxColumn);
                        }
                        else if (isBooleanColumn)
                        {
                            // Создаем колонку с CheckBox
                            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                            checkBoxColumn.HeaderText = header;
                            checkBoxColumn.Name = col_names[col - 1];
                            checkBoxColumn.TrueValue = true;
                            checkBoxColumn.FalseValue = false;
                            dataGridView.Columns.Add(checkBoxColumn);
                        }
                        else
                        {
                            // Обычная текстовая колонка
                            dataGridView.Columns.Add(col_names[col - 1], header);
                        }
                    }

                    // Заполняем данными, начиная со второй строки
                    for (int row = 2; row <= rowCount; row++)
                    {
                        DataGridViewRow dataGridViewRow = new DataGridViewRow();
                        dataGridViewRow.CreateCells(dataGridView);

                        for (int col = 1; col <= colCount; col++)
                        {
                            string cellValue = worksheet.Cells[row, col].Value?.ToString() ?? "";
                            var column = dataGridView.Columns[col - 1];

                            // Обрабатываем ComboBox колонку
                            if (column is DataGridViewComboBoxColumn)
                            {
                                // Устанавливаем значение, если оно есть в списке допустимых
                                if (comboBoxItems.Contains(cellValue))
                                {
                                    dataGridViewRow.Cells[col - 1].Value = cellValue;
                                }
                                else
                                {
                                    // Если значение не из списка, устанавливаем первое значение по умолчанию
                                    dataGridViewRow.Cells[col - 1].Value = comboBoxItems[0];
                                }
                            }
                            // Если колонка CheckBox, преобразуем значение
                            else if (column is DataGridViewCheckBoxColumn)
                            {
                                bool boolValue = ConvertToBoolean(cellValue);
                                dataGridViewRow.Cells[col - 1].Value = boolValue;
                            }

                            else
                            {
                                dataGridViewRow.Cells[col - 1].Value = cellValue;
                            }
                        }

                        dataGridView.Rows.Add(dataGridViewRow);
                    }

                    // Автоподбор ширины колонок
                    dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при импорте из Excel: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool IsColumnBoolean(ExcelWorksheet worksheet, int columnIndex, int rowCount)
        {
            int booleanCount = 0;
            int totalCells = 0;

            for (int row = 2; row <= rowCount; row++)
            {
                string cellValue = worksheet.Cells[row, columnIndex].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(cellValue))
                {
                    totalCells++;
                    if (IsBooleanValue(cellValue))
                    {
                        booleanCount++;
                    }
                }
            }

            // Если больше 70% значений в колонке - булевые, считаем колонку CheckBox
            return totalCells > 0 && (booleanCount * 100 / totalCells) >= 70;
        }

        // Метод для проверки, является ли значение булевым
        private static bool IsBooleanValue(string value)
        {
            string lowerValue = value.Trim().ToLower();
            return lowerValue == "true" || lowerValue == "false" ||
                   lowerValue == "yes" || lowerValue == "no" ||
                   lowerValue == "да" || lowerValue == "нет";
        }

        // Метод для преобразования строки в bool
        private static bool ConvertToBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            string lowerValue = value.Trim().ToLower();

            switch (lowerValue)
            {
                case "true":
                case "1":
                case "yes":
                case "да":
                    return true;
                case "false":
                case "0":
                case "no":
                case "нет":
                    return false;
                default:
                    return false; // По умолчанию false
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDataModified)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Есть несохраненные изменения. Хотите сохранить файл перед закрытием?",
                "Сохранение изменений",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);


            switch (result)
            {
                case DialogResult.Yes:

                    if (currentFilePath == null)
                    {
                        SaveDialog();
                    }
                    // Пользователь хочет сохранить
                    if (!ImportFromExcel(dataGridView1, currentFilePath))
                    {
                        // Если сохранение отменено или не удалось, отменяем закрытие
                        e.Cancel = true;
                    }
                    break;

                case DialogResult.No:
                    // Пользователь не хочет сохранять - просто закрываем
                    break;

                case DialogResult.Cancel:
                    // Пользователь отменил закрытие
                    e.Cancel = true;
                    break;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell || dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                // Если изменение произошло, принудительно фиксируем его
                // Это немедленно спровоцирует событие CellValueChanged
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            update_penalties();
        }
        private void сохарнитьКоэффициентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTextToFile(CorrectionCoeff.ToString());
        }
        private void загрузитьКоэффициентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTextFromFile();
        }

        private void toolStripTextBox1_CommandChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Изменено");
        }

        private void SaveTextToFile(string textToSave)
        {
            // Создаем диалог сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Настройки диалога
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Сохранить текстовый файл";
            saveFileDialog.FileName = "coef";

            // Показываем диалог и проверяем, нажал ли пользователь OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Сохраняем текст в файл
                    File.WriteAllText(saveFileDialog.FileName, textToSave);
                    MessageBox.Show("Файл успешно сохранен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadTextFromFile()
        {
            // Создаем диалог открытия файла
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройки диалога
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Открыть текстовый файл";
            openFileDialog.CheckFileExists = true; // Проверяем, что файл существует

            // Показываем диалог
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем текст из файла
                    string fileContent = File.ReadAllText(openFileDialog.FileName);


                    if (double.TryParse(fileContent, out double coeff))
                    {
                        CorrectionCoeff = coeff;
                        toolStripTextBox1.Text = Math.Round(CorrectionCoeff, 4).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Введено некорректное значение", "Ошибка");
                    }

                    MessageBox.Show("Файл успешно загружен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ToolStripTextBox tb = toolStripTextBox1;
            tb.KeyDown -= toolStripTextBox1_KeyDown;
            MainMenuStrip.Focus();

            tb.Text = tb.Text.Replace('.', ',');
            if (double.TryParse(tb.Text, out double coeff))
            {
                CorrectionCoeff = coeff;
            }
            else
            {
                tb.Text = Math.Round(CorrectionCoeff, 7).ToString();
                MessageBox.Show("Введено некорректное значение", "Ошибка");
            }

            tb.KeyDown += toolStripTextBox1_KeyDown;
        }
    }
}
