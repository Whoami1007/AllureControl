namespace Main
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            HName = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            time = new DataGridViewTextBoxColumn();
            RZ_Exit = new DataGridViewCheckBoxColumn();
            Sboy = new DataGridViewCheckBoxColumn();
            Zastyp = new DataGridViewComboBoxColumn();
            bonus = new DataGridViewTextBoxColumn();
            penalty = new DataGridViewTextBoxColumn();
            distance = new DataGridViewTextBoxColumn();
            button1 = new Button();
            idTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            nameTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            протяжённостьДистанцииToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            используемыеАллюрыToolStripMenuItem = new ToolStripMenuItem();
            HallopToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            RunToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            StepToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            очиститьToolStripMenuItem1 = new ToolStripMenuItem();
            button2 = new Button();
            panel1 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            button6 = new Button();
            label4 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            label9 = new Label();
            comboBox1 = new ComboBox();
            button9 = new Button();
            startAllButton = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel3 = new Panel();
            label8 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            button3 = new Button();
            label12 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label11 = new Label();
            button4 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Number, id, name, HName, type, time, RZ_Exit, Sboy, Zastyp, bonus, penalty, distance });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(3, 105);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1070, 501);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellEndEdit;
            dataGridView1.CellContentClick += dataGridView1_CellEndEdit;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellValueChanged += dataGridView1_CellEndEdit;
            dataGridView1.DataError += dataGridView1_DataError;
            // 
            // Number
            // 
            Number.HeaderText = "Номер старта";
            Number.Name = "Number";
            Number.ReadOnly = true;
            // 
            // id
            // 
            id.HeaderText = "Номер участника";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // name
            // 
            name.HeaderText = "ФИО";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // HName
            // 
            HName.HeaderText = "Клчика лошади";
            HName.Name = "HName";
            HName.ReadOnly = true;
            // 
            // type
            // 
            type.HeaderText = "Тип аллюра";
            type.Name = "type";
            type.ReadOnly = true;
            // 
            // time
            // 
            time.HeaderText = "Время на дистанции (с)";
            time.Name = "time";
            time.ReadOnly = true;
            // 
            // RZ_Exit
            // 
            RZ_Exit.HeaderText = "Выход из РЗ";
            RZ_Exit.Name = "RZ_Exit";
            // 
            // Sboy
            // 
            Sboy.HeaderText = "Сбой";
            Sboy.Name = "Sboy";
            // 
            // Zastyp
            // 
            Zastyp.HeaderText = "Заступы";
            Zastyp.Items.AddRange(new object[] { "0", "1", "2", "3", "4+" });
            Zastyp.Name = "Zastyp";
            // 
            // bonus
            // 
            bonus.HeaderText = "Оценка за время";
            bonus.Name = "bonus";
            bonus.Resizable = DataGridViewTriState.True;
            bonus.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // penalty
            // 
            penalty.HeaderText = "Штраф";
            penalty.Name = "penalty";
            // 
            // distance
            // 
            distance.HeaderText = "Дистанция";
            distance.Name = "distance";
            distance.ReadOnly = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(837, 3);
            button1.Name = "button1";
            button1.Size = new Size(95, 25);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // idTextBox
            // 
            idTextBox.Dock = DockStyle.Fill;
            idTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            idTextBox.Location = new Point(278, 34);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(295, 25);
            idTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(92, 14);
            label2.Name = "label2";
            label2.Size = new Size(91, 17);
            label2.TabIndex = 5;
            label2.Text = "Номер старта";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(618, 14);
            label3.Name = "label3";
            label3.Size = new Size(37, 17);
            label3.TabIndex = 7;
            label3.Text = "ФИО";
            // 
            // nameTextBox
            // 
            nameTextBox.Dock = DockStyle.Fill;
            nameTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nameTextBox.Location = new Point(579, 34);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(115, 25);
            nameTextBox.TabIndex = 6;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, очиститьToolStripMenuItem, протяжённостьДистанцииToolStripMenuItem, используемыеАллюрыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1395, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { сохранитьToolStripMenuItem, toolStripMenuItem1 });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(133, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(133, 22);
            toolStripMenuItem1.Text = "Открыть...";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(71, 20);
            очиститьToolStripMenuItem.Text = "Очистить";
            очиститьToolStripMenuItem.Click += очиститьToolStripMenuItem_Click;
            // 
            // протяжённостьДистанцииToolStripMenuItem
            // 
            протяжённостьДистанцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4 });
            протяжённостьДистанцииToolStripMenuItem.Name = "протяжённостьДистанцииToolStripMenuItem";
            протяжённостьДистанцииToolStripMenuItem.Size = new Size(167, 20);
            протяжённостьДистанцииToolStripMenuItem.Text = "Протяжённость дистанции";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem3.CheckState = CheckState.Checked;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(92, 22);
            toolStripMenuItem3.Text = "100";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(92, 22);
            toolStripMenuItem4.Text = "150";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // используемыеАллюрыToolStripMenuItem
            // 
            используемыеАллюрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { HallopToolStripMenuItem, RunToolStripMenuItem, StepToolStripMenuItem, очиститьToolStripMenuItem1 });
            используемыеАллюрыToolStripMenuItem.Name = "используемыеАллюрыToolStripMenuItem";
            используемыеАллюрыToolStripMenuItem.Size = new Size(151, 20);
            используемыеАллюрыToolStripMenuItem.Text = "Используемые аллюры";
            // 
            // HallopToolStripMenuItem
            // 
            HallopToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });
            HallopToolStripMenuItem.Name = "HallopToolStripMenuItem";
            HallopToolStripMenuItem.Size = new Size(126, 22);
            HallopToolStripMenuItem.Text = "Галоп";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(80, 22);
            toolStripMenuItem5.Text = "1";
            toolStripMenuItem5.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(80, 22);
            toolStripMenuItem6.Text = "2";
            toolStripMenuItem6.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(80, 22);
            toolStripMenuItem7.Text = "3";
            toolStripMenuItem7.Click += SelectAllureFrom_Click;
            // 
            // RunToolStripMenuItem
            // 
            RunToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10 });
            RunToolStripMenuItem.Name = "RunToolStripMenuItem";
            RunToolStripMenuItem.Size = new Size(126, 22);
            RunToolStripMenuItem.Text = "Рысь";
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(80, 22);
            toolStripMenuItem8.Text = "1";
            toolStripMenuItem8.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(80, 22);
            toolStripMenuItem9.Text = "2";
            toolStripMenuItem9.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(80, 22);
            toolStripMenuItem10.Text = "3";
            toolStripMenuItem10.Click += SelectAllureFrom_Click;
            // 
            // StepToolStripMenuItem
            // 
            StepToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem11, toolStripMenuItem12, toolStripMenuItem13 });
            StepToolStripMenuItem.Name = "StepToolStripMenuItem";
            StepToolStripMenuItem.Size = new Size(126, 22);
            StepToolStripMenuItem.Text = "Шаг";
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(80, 22);
            toolStripMenuItem11.Text = "1";
            toolStripMenuItem11.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(80, 22);
            toolStripMenuItem12.Text = "2";
            toolStripMenuItem12.Click += SelectAllureFrom_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(80, 22);
            toolStripMenuItem13.Text = "3";
            toolStripMenuItem13.Click += SelectAllureFrom_Click;
            // 
            // очиститьToolStripMenuItem1
            // 
            очиститьToolStripMenuItem1.Name = "очиститьToolStripMenuItem1";
            очиститьToolStripMenuItem1.Size = new Size(126, 22);
            очиститьToolStripMenuItem1.Text = "Очистить";
            очиститьToolStripMenuItem1.Click += очиститьToolStripMenuItem1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(278, 67);
            button2.Name = "button2";
            button2.Size = new Size(295, 26);
            button2.TabIndex = 9;
            button2.Text = "Удалить выбранное";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1079, 105);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 501);
            panel1.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(button6, 0, 5);
            tableLayoutPanel3.Controls.Add(label4, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Controls.Add(button9, 0, 2);
            tableLayoutPanel3.Controls.Add(startAllButton, 0, 3);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 4);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 6;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 36.0655746F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 63.9344254F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 102F));
            tableLayoutPanel3.Size = new Size(310, 499);
            tableLayoutPanel3.TabIndex = 18;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button6.Location = new Point(3, 399);
            button6.Name = "button6";
            button6.Size = new Size(304, 97);
            button6.TabIndex = 20;
            button6.Text = "Полная отмена участника";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(66, 0);
            label4.Name = "label4";
            label4.Size = new Size(177, 21);
            label4.TabIndex = 8;
            label4.Text = "Управление станциями";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label9, 0, 0);
            tableLayoutPanel4.Controls.Add(comboBox1, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(304, 38);
            tableLayoutPanel4.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(146, 38);
            label9.TabIndex = 16;
            label9.Text = "Выбор порта подключения";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(155, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(146, 23);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // button9
            // 
            button9.Dock = DockStyle.Fill;
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button9.Location = new Point(3, 72);
            button9.Name = "button9";
            button9.Size = new Size(304, 59);
            button9.TabIndex = 17;
            button9.Text = "Обновить COM-порты";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // startAllButton
            // 
            startAllButton.Dock = DockStyle.Fill;
            startAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            startAllButton.Location = new Point(3, 137);
            startAllButton.Name = "startAllButton";
            startAllButton.Size = new Size(304, 116);
            startAllButton.TabIndex = 13;
            startAllButton.Text = "Начать счёт времени для выбранного участника";
            startAllButton.UseVisualStyleBackColor = true;
            startAllButton.Click += startAllButton_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(panel3, 1, 0);
            tableLayoutPanel5.Controls.Add(panel2, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 259);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(304, 134);
            tableLayoutPanel5.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label8);
            panel3.Enabled = false;
            panel3.Location = new Point(155, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(146, 128);
            panel3.TabIndex = 15;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label8.Location = new Point(39, 0);
            label8.Name = "label8";
            label8.Size = new Size(62, 21);
            label8.TabIndex = 9;
            label8.Text = "Финиш";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Enabled = false;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(146, 128);
            panel2.TabIndex = 10;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(43, 0);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 9;
            label5.Text = "Старт";
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(3, 67);
            button3.Name = "button3";
            button3.Size = new Size(269, 26);
            button3.TabIndex = 11;
            button3.Text = "Обнулить время";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Bottom;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label12.Location = new Point(715, 14);
            label12.Name = "label12";
            label12.Size = new Size(101, 17);
            label12.TabIndex = 17;
            label12.Text = "Кличка лошади";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(700, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(131, 25);
            textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox2.Location = new Point(3, 34);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(269, 25);
            textBox2.TabIndex = 18;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label11.Location = new Point(370, 14);
            label11.Name = "label11";
            label11.Size = new Size(111, 17);
            label11.TabIndex = 19;
            label11.Text = "Номер участника";
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(837, 34);
            button4.Name = "button4";
            button4.Size = new Size(95, 27);
            button4.TabIndex = 21;
            button4.Text = "Обновить таблицу";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.18795F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.8120518F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Location = new Point(0, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.7487679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 83.25123F));
            tableLayoutPanel1.Size = new Size(1394, 609);
            tableLayoutPanel1.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.7366257F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.2633743F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 121F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 137F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 134F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(textBox2, 0, 1);
            tableLayoutPanel2.Controls.Add(button4, 4, 1);
            tableLayoutPanel2.Controls.Add(button3, 0, 2);
            tableLayoutPanel2.Controls.Add(label11, 1, 0);
            tableLayoutPanel2.Controls.Add(button1, 4, 0);
            tableLayoutPanel2.Controls.Add(textBox1, 3, 1);
            tableLayoutPanel2.Controls.Add(label12, 3, 0);
            tableLayoutPanel2.Controls.Add(idTextBox, 1, 1);
            tableLayoutPanel2.Controls.Add(button2, 1, 2);
            tableLayoutPanel2.Controls.Add(nameTextBox, 2, 1);
            tableLayoutPanel2.Controls.Add(label3, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 48.4375F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 51.5625F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.Size = new Size(1070, 96);
            tableLayoutPanel2.TabIndex = 23;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1395, 663);
            Controls.Add(menuStrip1);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Главная Форма";
            FormClosing += Main_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private TextBox idTextBox;
        private Label label2;
        private Label label3;
        private TextBox nameTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private Button button2;
        private Panel panel1;
        private Label label4;
        private Button startAllButton;
        private Panel panel2;
        private Label label5;
        private Button button3;
        private Panel panel3;
        private Label label8;
        private Label label9;
        private ComboBox comboBox1;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private Label label12;
        private TextBox textBox1;
        private ToolStripMenuItem протяжённостьДистанцииToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private TextBox textBox2;
        private Label label11;
        private Button button9;
        private ToolStripMenuItem используемыеАллюрыToolStripMenuItem;
        private ToolStripMenuItem HallopToolStripMenuItem;
        private ToolStripMenuItem RunToolStripMenuItem;
        private ToolStripMenuItem StepToolStripMenuItem;
        private Button button6;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem очиститьToolStripMenuItem1;
        private Button button4;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn HName;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn time;
        private DataGridViewCheckBoxColumn RZ_Exit;
        private DataGridViewCheckBoxColumn Sboy;
        private DataGridViewComboBoxColumn Zastyp;
        private DataGridViewTextBoxColumn bonus;
        private DataGridViewTextBoxColumn penalty;
        private DataGridViewTextBoxColumn distance;
    }
}
