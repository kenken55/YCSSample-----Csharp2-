using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace timer02
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();  // タイマー
        private System.Media.SoundPlayer player = null;
 
        string path = @"C:\Users\KAZUKI\Music\sample01.wav";
        int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
        DateTime datetime_set;
 
        public Form1()
        {
            InitializeComponent();
            // 更新間隔 (ミリ秒)
            timer.Interval = 1000;
            // タイマ用のイベントハンドラを登録
            timer.Tick += new EventHandler(timer_Tick);
            // タイマ ON
            timer.Start();
        }
 
        // Tick イベントのイベントハンドラ
        void timer_Tick(object sender, EventArgs e)
        {
            // 現在時を取得
            DateTime datetime = DateTime.Now;
 
            // ラベルに現在時刻を表示
            label_time_now.Text = datetime.ToLongTimeString();
 
            //現在の時間が設定の時間になった時の処理
            if (datetime.ToLongTimeString() == datetime_set.ToLongTimeString())
                PlaySound(path);
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            hour = int.Parse(textBox3.Text);
            minute = int.Parse(textBox5.Text);
            second = int.Parse(textBox6.Text);
 
            datetime_set = new DateTime(year, month, day, hour, minute, second);
            label_time_set.Text = datetime_set.ToLongTimeString();
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            //現在の時刻の所得
            DateTime datetime = DateTime.Now;
 
            //年を取得する。「2000」となる。
            year = datetime.Year;
            //月を取得する。「9」となる。
            month = datetime.Month;
            //日を取得する。「30」となる。
            day = datetime.Day;
            //時間を取得する。
            textBox3.Text = datetime.Hour.ToString();
            //分を取得する。
            textBox5.Text = datetime.Minute.ToString();
            //秒を取得する。
            textBox6.Text = datetime.Second.ToString();
        }
 
        private void button3_Click(object sender, EventArgs e)
        {
            // OpenFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // ダイアログのタイトルを設定する
            openFileDialog1.Title = "ダイアログのタイトルをココに書く";
            // 初期表示するディレクトリを設定する
            openFileDialog1.InitialDirectory = @"C:\";
            // 初期表示するファイル名を設定する
            openFileDialog1.FileName = "初期表示するファイル名をココに書く";
            // ファイルのフィルタを設定する
            openFileDialog1.Filter = "テキスト ファイル|*.txt;*.log|すべてのファイル|*.*";
            // ファイルの種類 の初期設定を 2 番目に設定する (初期値 1)
            openFileDialog1.FilterIndex = 2;
            // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 false)
            openFileDialog1.RestoreDirectory = true;
            // 複数のファイルを選択可能にする (初期値 false)
            openFileDialog1.Multiselect = true;
 
            // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = openFileDialog1.FileName;
                path = openFileDialog1.FileName;
            }
 
            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            openFileDialog1.Dispose();
        }
 
        //再生
        private void PlaySound(string waveFile)
        {
            //音声が再生されている場合停止する
            if (player != null)
                StopSound();
 
            player = new System.Media.SoundPlayer(waveFile);
            player.Play(); //再生
        }
 
        //停止
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }
    }
}