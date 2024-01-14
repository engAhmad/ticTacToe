using System;
using System.Windows.Forms;

namespace ticTacToe
{
    public partial class Form1 : Form
    {
        // **تخزن لاعب الدور الحالي (true لـ X ، false لـ O)**
        bool turn = true;
        // **يحسب عدد الدورات التي تم اتخاذها**
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // **يعرض معلومات حول اللعبة**
            MessageBox.Show("من تصميم المهندس أحمد الطراونه", "  لعبة أكس او");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // **يغلق التطبيق**
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            // **يتعامل مع نقر الزر على لوحة اللعبة**
            Button b = (Button)sender;  // يحول المرسل إلى كائن Button

            if (turn)
            {
                b.Text = "X";  // يضع نص الزر على "X" إذا كان دور X
            }
            else
            {
                b.Text = "O";  // يضع نص الزر على "O" إذا كان دور O
            }

            turn = !turn;  // يغير الدور
            b.Enabled = false;  // يعطل الزر الذي تم النقر عليه
            turn_count++;  // يزيد عدد الدورات

            checkForWinner();  // يتحقق مما إذا كان هناك فائز بعد الحركة
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            // **يتحقق من الفوز الأفقي**
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            // **يتحقق من الفوز الرأسي**
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            // **يتحقق من الفوز القطري**
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                // **يعطل جميع الأزرار إذا كان هناك فائز**
                disableButtons();
                string winner = turn ? "O" : "X";  // يحدد الفائز
                MessageBox.Show(winner + " يفوز", "رائع");  // يعرض الفائز
            }
            else if (turn_count == 9)
            {
                // **يعرض رسالة تعادل إذا تم ملء جميع المساحات**
                MessageBox.Show("تعادل", "تعادل");
            }
        }

        // **يعطل جميع الأزرار الموجودة على النموذج**
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;  // يحول التحكم إلى كائن Button
                    b.Enabled = false;    // يعطل الزر
                }
            }
            catch { }  // يمسك أي استثناءات قد تحدث أثناء تعطيل الأزرار
        }

        // **يبدأ لعبة جديدة**
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;          // يعيد تعيين الدور إلى X
            turn_count = 0;      // يعيد تعيين عدد الدورات إلى 0

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;  // يحول التحكم إلى كائن Button
                    b.Enabled = true;     // يمكّن الزر
                    b.Text = "";         // يزيل النص من الزر
                }
            }
            catch { }  // يمسك أي استثناءات قد تحدث أثناء تمكين الأزرار
        }
    }
}
