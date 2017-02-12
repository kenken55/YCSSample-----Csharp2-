using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Timers;

namespace WindowsFormsApplication1
{
    public class Form1 : Form //Designer.cs を削除
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        PictureBox pb = new PictureBox();
        //リソースからファイル取得
        //リソースは「プロジェクトのプロパティ＞リソース」から追加
        Bitmap plate = Properties.Resources.WheelBlackSmall2; //文字盤
        Bitmap hou = Properties.Resources.hou2; //時針
        Bitmap min = Properties.Resources.min2; //分針
        Bitmap sec = Properties.Resources.sec2; //秒針
        //タイマー
        System.Timers.Timer tm = new System.Timers.Timer();
        float thsec = 0F; //時針の回転角
        float thmin = 0F; //分針の回転角
        float thhou = 0F; //秒針の回転角
        //定期的に時刻あわせするためのパラメータ
        private int count;
        //クリックした場所を記憶する
        private Point mp = new Point();
        //ツールチップ
        ToolTip tt = new ToolTip();

        public Form1()
        {
            this.components = new System.ComponentModel.Container();
            this.Text = "Form1";
            this.ClientSize = new Size(200, 200);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = SystemColors.Control;
            //フォームを透明に
            this.TransparencyKey = SystemColors.Control;
            //文字盤
            this.BackgroundImage = plate;
            this.BackgroundImageLayout = ImageLayout.None;
            this.Controls.Add(pb);
            //ピクチャボックス
            this.pb.Dock = DockStyle.None;
            this.pb.SetBounds(0, 0, 200, 200);
            this.pb.BackColor = Color.Transparent; //透明
            //ドラッグできるようにする
            this.pb.MouseDown += new MouseEventHandler(pb_MouseDown);
            this.pb.MouseMove += new MouseEventHandler(pb_MouseMove);
            this.pb.DoubleClick += new EventHandler(pb_DoubleClick);
            //ツールチップ
            this.tt.ShowAlways = true;
            this.tt.SetToolTip(pb, "ダブルクリックで閉じます");
            //タイマー
            this.tm.Enabled = true;
            this.tm.AutoReset = true;
            //ここを100とか50にすると滑らかな秒針の動きが実現できる
            this.tm.Interval = 1000;
            this.tm.Elapsed += new ElapsedEventHandler(tm_Tick); 
            
            TimeSet();
            tm.Start();
        }

        //時刻合わせ
        private void TimeSet()
        {
            DateTime dt = DateTime.Now;
            thsec = (float)(dt.Second * 6);
            thmin = (float)(dt.Minute * 6 + dt.Second * 0.1);
            thhou = (float)(dt.Hour * 30 + dt.Minute * 0.5 + dt.Second * 0.5 / 60);

            //デモ用に針の位置合わせ
            /*
            thsec = 0 * 6;
            thmin = 10 * 6;
            thhou = 10 * 30 + 10 * 0.5F;
            */

            if (thhou > 360) { thhou -= 360; }
            if (thmin > 360) { thmin -= 360; }
            if (thsec > 360) { thsec -= 360; }
            Rotate();
        }

        //タイマーが刻むときの処理
        void tm_Tick(object sender, EventArgs e)
        {
            ++count;
            if (count == (int)(3600 * 1000 / tm.Interval)) //1時間に1回針合わせ
            {
                count = 0;
                TimeSet();
            }
            else //針を進める
            {
                thhou += (float)(0.1 * (0.001 * tm.Interval) / 60);
                thmin += (float)(0.1 * (0.001 * tm.Interval));
                thsec += (float)(6 * (0.001 * tm.Interval));
                if (thhou > 360) { thhou -= 360; }
                if (thmin > 360) { thmin -= 360; }
                if (thsec > 360) { thsec -= 360; }
                Rotate();
            }
        }

        //針を描画
        private void Rotate()
        {
            Bitmap sheet = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(sheet);
            
            //複数の画像を重ね書きするため clear しないで続ける
            g.TranslateTransform(-100, -100); //画像の中心が原点にくるよう平行移動
            g.RotateTransform(thhou, MatrixOrder.Append); //原点の周りに回転
            g.TranslateTransform(100, 100, MatrixOrder.Append); //平行移動して戻す
            
            g.DrawImageUnscaled(hou, 0, 0);

            g.TranslateTransform(-100, -100, MatrixOrder.Append);
            //前の回転をいったん取り消し新しい角度を適用
            g.RotateTransform(-thhou + thmin, MatrixOrder.Append);
            g.TranslateTransform(100, 100, MatrixOrder.Append);

            g.DrawImageUnscaled(min, 0, 0);

            g.TranslateTransform(-100, -100, MatrixOrder.Append);
            g.RotateTransform(-thmin + thsec, MatrixOrder.Append);
            g.TranslateTransform(100, 100, MatrixOrder.Append);

            g.DrawImageUnscaled(sec, 0, 0);

            pb.Image = sheet; //ピクチャボックスに出力
            g.Dispose();
        }

        //クリックした場所を記録
        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            mp = new Point(e.X, e.Y);
        }

        //ドラッグと同時にフォームを動かす
        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mp.X;
                this.Top += e.Y - mp.Y;
            }
        }

        //ダブルクリックで閉じる
        void pb_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}