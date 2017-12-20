using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// http://freeprog.tistory.com/238
namespace comboBox_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            prepare_comboBox();
        }

        public void prepare_comboBox()
        {
            comboBox1.Items.Add("test1"); // item 추가하기 
            comboBox1.Items.Add("test2");
            comboBox1.Items.Add("test3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] grp = { "G1", "G2", "G3" };
            comboBox1.Items.AddRange(grp); // item 배열 추가하기 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.DataSource == null) // data binding 아니면, 삭제 
            {
                comboBox1.Items.Remove("test2"); // 삭제 방법 1 
                comboBox1.Items.RemoveAt(0); // 삭제 방법 2 
            }
            else {
                MessageBox.Show("data binding 시에는 삭제 방법 다릅니다...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.DataSource == null)
            {
                comboBox1.Items.Clear(); // data biding 시에는 사용 못함. .. 
            }
            else
            {
                MessageBox.Show("data binding 시에는 삭제 방법 다릅니다...");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = comboBox1.SelectedIndex;
            String txt = comboBox1.SelectedItem as String; // 아래 2가지는 안됨.... 
            // String txt = comboBox1.SelectedText; 
            // String txt = comboBox1.SelectedValue as String; 

            if (sel > -1)
            {
                String msg = String.Format("selected index == {0}, {1}, {2}", sel, comboBox1.Items[sel], txt);
                MessageBox.Show(msg);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.Simple;
            comboBox1.Size = new System.Drawing.Size(comboBox1.Width, 150); // 필수 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        static Dictionary<int, String> dict_newitems = new Dictionary<int, string>(); // data binding --- DB 와도 binding 가능하다.. 

        private void button7_Click(object sender, EventArgs e)
        {
            dict_newitems[2] = "two";
            dict_newitems[3] = "three";
            dict_newitems.Add(5, "five");
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = new BindingSource(dict_newitems, null);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // bind 해제 
            comboBox1.DataSource = null;
            dict_newitems.Remove(2); // data 삭제
                                     // 다시 bind 
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = new BindingSource(dict_newitems, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = null; dict_newitems.Clear(); // 모든 데이터 삭제 
        }
        
        // 값 선택하기 
        private void button10_Click(object sender, EventArgs e)
        {
            String str = "test3";
            if (comboBox1.Items.Contains(str))
            {
                comboBox1.SelectedItem = str; // 방법 1 
                                              // comboBox1.SelectedIndex = comboBox1.FindStringExact(str); // 방법 2 
            }
            else
            {
                MessageBox.Show("찾을수가 없습니다...");
            }
        }
    }
}

