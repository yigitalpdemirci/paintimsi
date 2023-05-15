using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace paintApp
{
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();
        }

        private enum Mode
        {
            Rectangle, 
            Triangle, 
            Circle, 
            Hexagon, 
            Delete, 
            Select
        }

        private static Mode mode;
        private static Shape currentPictureBox;
        private static List<Shape> shapeList = new List<Shape>();

        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;
        private Color currentColor;
        
        //For Button Highlighting..
        private void deselectOtherButtons(String buttonType, Button selectedButton)
        {

            deleteButton.FlatStyle = FlatStyle.Standard;
            selectButton.FlatStyle = FlatStyle.Standard;
            clearBoardButton.FlatStyle = FlatStyle.Standard;
            if (buttonType == "Shape")
            {
                rectangleButton.FlatStyle = FlatStyle.Standard;
                circleButton.FlatStyle = FlatStyle.Standard;
                hexagonButton.FlatStyle = FlatStyle.Standard;
                triangleButton.FlatStyle = FlatStyle.Standard;
            }
            else if (buttonType == "Color")
            {
                redButton.FlatStyle = FlatStyle.Standard;
                blueButton.FlatStyle = FlatStyle.Standard;
                greenButton.FlatStyle = FlatStyle.Standard;
                orangeButton.FlatStyle = FlatStyle.Standard;
                blackButton.FlatStyle = FlatStyle.Standard;
                yellowButton.FlatStyle = FlatStyle.Standard;
                purpleButton.FlatStyle = FlatStyle.Standard;
                whiteButton.FlatStyle = FlatStyle.Standard;
            }
            else if (buttonType == "Mode")
            {
                rectangleButton.FlatStyle = FlatStyle.Standard;
                circleButton.FlatStyle = FlatStyle.Standard;
                hexagonButton.FlatStyle = FlatStyle.Standard;
                triangleButton.FlatStyle = FlatStyle.Standard;
                redButton.FlatStyle = FlatStyle.Standard;
                blueButton.FlatStyle = FlatStyle.Standard;
                greenButton.FlatStyle = FlatStyle.Standard;
                orangeButton.FlatStyle = FlatStyle.Standard;
                blackButton.FlatStyle = FlatStyle.Standard;
                yellowButton.FlatStyle = FlatStyle.Standard;
                purpleButton.FlatStyle = FlatStyle.Standard;
                whiteButton.FlatStyle = FlatStyle.Standard;
            }
            if (selectedButton != null)
            {
                selectedButton.FlatStyle = FlatStyle.Flat;
            }

        }

        // Shape class (Inherits pictureBox) Using encapsulation and abstraction.


        private abstract class Shape : PictureBox
        {
            private int x;
            private int y;
            private String shapeName;
            private int xLength;
            private int yLength;
            private Color color;
            private Button colorButton;
            private Button shapeButton;

            private bool isMoving;
            private Point lastLocation;

            public Shape()
            {
                MouseDown += Shape_MouseDown;
                MouseMove += Shape_MouseMove;
                MouseUp += Shape_MouseUp;
            }
            public Shape(int x, int y, int xLength, int yLength, Color color, Graphics g)
            {
                this.x = x;
                this.y = y;
                this.xLength = xLength;
                this.yLength = yLength;
                this.color = color;
                MouseDown += Shape_MouseDown;
                MouseMove += Shape_MouseMove;
                MouseUp += Shape_MouseUp;
            }

            public String ShapeName {
                get { return shapeName; }
                set { shapeName = value; } 
            }
            
            public int X
            {
                get { return x; } 
                set { x = value; }
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public int XLength
            {
                get { return XLength; }
                set { XLength = value; }
            }

            public int YLength
            {
                get { return YLength; }
                set { YLength = value; }
            }

            public Color Color
            {
                get { return color; }
                set { color = value; }
            }

            public Button ColorButton
            {
                get { return colorButton; }
                set { colorButton = value; }
            }

            public Button ShapeButton
            {
                get { return shapeButton; }
                set { shapeButton = value; }
            }

            internal abstract void DrawShape(Color color, int width, int height, Graphics g);
            internal void ChangeColor(Color color)
            {
                this.color = color;
                using (Graphics g = Graphics.FromImage(this.Image))
                {
                    currentPictureBox.DrawShape(color, this.Width, this.Height, g);
                }
                currentPictureBox.Refresh();
            }

            private void Shape_MouseDown(object sender, MouseEventArgs e)
            {
                currentPictureBox = (Shape)sender;

                if (mode == Mode.Select)
                {
                    isMoving = true;
                    lastLocation = e.Location;
                }
                if (mode == Mode.Delete)
                {
                    shapeList.Remove(this);
                    Parent.Controls.Remove(this);
                }
            }

            private void Shape_MouseMove(object sender, MouseEventArgs e)
            {
                if (isMoving)
                {
                    int deltaX = e.Location.X - lastLocation.X;
                    int deltaY = e.Location.Y - lastLocation.Y;
                    int finalX = this.Location.X + deltaX;
                    int finalY = this.Location.Y + deltaY;

                    // Prevents crossing borders
                    if (finalX <= 0)
                    {
                        finalX = 0;
                    }
                    if (finalY <= 0)
                    {
                        finalY = 0;
                    }

                    if (finalX + Width > Parent.ClientSize.Width)
                    {
                        finalX = Parent.ClientSize.Width - Width;
                    }

                    if (finalY + Height > Parent.ClientSize.Height)
                    {
                        finalY = Parent.ClientSize.Height - Height;
                    }

                    this.Location = new Point(finalX, finalY);
                }
            }

            private void Shape_MouseUp(object sender, MouseEventArgs e)
            {
                isMoving = false;
            }

        }

        private class Rectangle : Shape
        {
            public Rectangle(int x, int y, int width, int height, Color color, Graphics g) : base(x, y, width,height, color, g)
            {
                DrawShape(color,width,height,g);

            }

            public Rectangle()
            {

            }
            internal override void DrawShape(Color color, int width, int height, Graphics g)
            {
                g.FillRectangle(new SolidBrush(color), 0, 0, width, height);
            }

        }

        private class Triangle : Shape
        {
            public Triangle(int x, int y, int width, int height, Color color, Graphics g) : base(x, y, width, height, color, g)
            {
                DrawShape(color, width, height, g);
            }

            public Triangle()
            {

            }
            internal override void DrawShape(Color color, int width, int height, Graphics g)
            {
                GraphicsPath trianglePath = new GraphicsPath();
                Point[] points = { new Point(width / 2, 0), new Point(0, height), new Point(width, height) };
                trianglePath.AddPolygon(points);
                g.Clip = new Region(trianglePath);
                g.FillRectangle(new SolidBrush(color), 0, 0, width, height);
            }
        }

        private class Ellipse : Shape
        {
            public Ellipse(int x, int y, int width, int height, Color color, Graphics g) : base(x, y, width, height, color, g)
            {
                DrawShape(color, width, height, g);
            }

            public Ellipse() { 
                
            }
            internal override void DrawShape(Color color, int width, int height, Graphics g)
            {
                GraphicsPath ellipsePath = new GraphicsPath();
                ellipsePath.AddEllipse(0, 0, width, height);
                g.Clip = new Region(ellipsePath);
                g.FillRectangle(new SolidBrush(color),0,0, width, height);
            }
        }

        private class Hexagon : Shape
        {
            public Hexagon(int x, int y, int width, int height, Color color, Graphics g) : base(x, y, width, height, color, g)
            {
                DrawShape(color, width, height,g);
            }

            public Hexagon() { }

            internal override void DrawShape(Color color, int width, int height, Graphics g)
            {
                GraphicsPath hexagonPath = new GraphicsPath();
                Point[] points = {new Point(0,height / 2),new Point(width / 3,0),new Point((2* width) / 3,0),new Point(width,height / 2), new Point((2 * width) / 3, height),new Point(width / 3,height)};
                hexagonPath.AddPolygon(points);
                g.Clip = new Region(hexagonPath);
                g.FillRectangle(new SolidBrush(color), 0, 0, width, height);
            }
        }
        private void triangleButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Shape",triangleButton);
            mode = Mode.Triangle;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Shape", circleButton);
            mode = Mode.Circle;

        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Shape", rectangleButton);
            mode = Mode.Rectangle;
        }

        private void hexagonButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Shape", hexagonButton);
            mode = Mode.Hexagon;
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", redButton);
            if(mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Red);
            }
            currentColor = Color.Red;
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", blueButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Blue);
            }
            currentColor = Color.Blue;
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", greenButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Green);
            }
            currentColor = Color.Green;
        }

        private void orangeButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", orangeButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Orange);
            }
            currentColor = Color.Orange;
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", blackButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Black);
            }
            currentColor = Color.Black;
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", yellowButton);
            if (mode == Mode.Select && currentPictureBox != null) 
            {
                currentPictureBox.ChangeColor(Color.Yellow);
            }
            currentColor = Color.Yellow;
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", purpleButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.Purple);
            }

            currentColor = Color.Purple;
        }

        private void whiteButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Color", whiteButton);
            if (mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(Color.White);
            }
            currentColor = Color.White;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Mode", selectButton);
            isDrawing = false;
            mode = Mode.Select;
            currentPictureBox = null;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Mode", deleteButton);
            isDrawing = false;
            mode = Mode.Delete;
            currentPictureBox = null;
        }

        private void clearBoardButton_Click(object sender, EventArgs e)
        {
            deselectOtherButtons("Mode", clearBoardButton);
            isDrawing = false;
            mode = Mode.Select;
            paintArea.Controls.Clear();
            shapeList.Clear();
            currentPictureBox = null;
        }
        private void paintArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == Mode.Select || mode == Mode.Delete)
            {
                return;
            }

            isDrawing = true;
            startPoint = e.Location;

            Shape temp = new Rectangle();
            switch(mode)
            {
                case Mode.Rectangle: 
                    temp = new Rectangle();
                    temp.ShapeName = "Rectangle";
                    temp.ShapeButton = rectangleButton;
                    break;
                case Mode.Triangle:
                    temp = new Triangle();
                    temp.ShapeName = "Triangle";
                    temp.ShapeButton = triangleButton;
                    break;
                case Mode.Circle:
                    temp = new Ellipse();
                    temp.ShapeName = "Ellipse";
                    temp.ShapeButton = circleButton;
                    break;
                case Mode.Hexagon: 
                    temp = new Hexagon();
                    temp.ShapeName = "Hexagon";
                    temp.ShapeButton = hexagonButton;
                    break;
            }
            temp.Location = startPoint;
            temp.X = startPoint.X;
            temp.Y = startPoint.Y;
            temp.Size = new Size(10, 10);
            temp.SizeMode = PictureBoxSizeMode.CenterImage;
            temp.Color = currentColor;

            if (currentColor == Color.Red)
            {
                temp.ColorButton = redButton;
            }
            else if (currentColor == Color.Blue)
            {
                temp.ColorButton = blueButton;
            }
            else if (currentColor == Color.Green)
            {
                temp.ColorButton = greenButton;
            } else if (currentColor == Color.Orange)
            {
                temp.ColorButton = orangeButton;
            } else if (currentColor == Color.Black)
            {
                temp.ColorButton = blackButton;
            } else if (currentColor == Color.Yellow)
            {
                temp.ColorButton = yellowButton;
            } else if (currentColor == Color.Purple)
            {
                temp.ColorButton = purpleButton;
            } else if (currentColor == Color.White)
            {
                temp.ColorButton = whiteButton;
            }

            paintArea.Controls.Add(temp);
            currentPictureBox = temp;
            currentPictureBox.BringToFront();
        }
        private void paintArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (mode == Mode.Select || mode == Mode.Delete)
            {
                return;
            }

            if (isDrawing == true)
            {
                endPoint = e.Location;
                int tempWidth = (2 * Math.Abs(endPoint.X - startPoint.X)) + 1;
                int tempHeight = (2 * Math.Abs(endPoint.Y - startPoint.Y)) + 1;


                if (tempWidth + startPoint.X >= paintArea.ClientSize.Width)
                {
                    tempWidth = paintArea.ClientSize.Width - startPoint.X;
                }

                if (tempHeight + startPoint.Y >= paintArea.ClientSize.Height)
                {
                    tempHeight = paintArea.ClientSize.Height - startPoint.Y;
                }

                currentPictureBox.Width = tempWidth;
                currentPictureBox.Height = tempHeight;
                Bitmap bmp = new Bitmap(tempWidth, tempHeight);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                }
                currentPictureBox.Image = bmp;
                using (Graphics g = Graphics.FromImage(currentPictureBox.Image))
                {
                    currentPictureBox.DrawShape(currentColor,tempWidth,tempHeight,g);
                }
                currentPictureBox.Refresh();
            }
        }
        private void paintArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (mode == Mode.Select || mode == Mode.Delete)
            {
                return;
            }
            shapeList.Add(currentPictureBox);
            endPoint = e.Location;
            isDrawing = false;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog inputFileDialog = new OpenFileDialog();
            inputFileDialog.Reset();
            inputFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            inputFileDialog.Filter = "Metin Belgesi Dosyası | *.txt";
            String str = new string(new char[] { }); ;

            if (inputFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = inputFileDialog.FileName;
                string fileName = inputFileDialog.SafeFileName;
                str = File.ReadAllText(inputFileDialog.FileName);
            }

            using (StringReader reader = new StringReader(str))
            {
                paintArea.Controls.Clear();
                shapeList.Clear();
                currentPictureBox = null;

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] splittedLine = line.Split(' ');
                    Shape temp = new Rectangle();
                    switch (splittedLine[0])
                    {
                        case "Rectangle":
                            temp = new Rectangle();
                            temp.ShapeName = "Rectangle";
                            temp.ShapeButton = rectangleButton;
                            break;
                        case "Triangle":
                            temp = new Triangle();
                            temp.ShapeName = "Triangle";
                            temp.ShapeButton = triangleButton;
                            break;
                        case "Ellipse":
                            temp = new Ellipse();
                            temp.ShapeName = "Ellipse";
                            temp.ShapeButton = circleButton;
                            break;
                        case "Hexagon":
                            temp = new Hexagon();
                            temp.ShapeName = "Hexagon";
                            temp.ShapeButton = hexagonButton;
                            break;
                    }
                    temp.X = Int32.Parse(splittedLine[1]);
                    temp.Y = Int32.Parse(splittedLine[2]);
                    temp.Location = new Point (temp.X,temp.Y);
                    temp.Size = new Size(Int32.Parse(splittedLine[3]), Int32.Parse(splittedLine[4]));
                    temp.SizeMode = PictureBoxSizeMode.CenterImage;

                    if (splittedLine[5] == "Red")
                    {
                        temp.ColorButton = redButton;
                        temp.Color = Color.Red;
                    }
                    else if (splittedLine[5] == "Blue")
                    {
                        temp.ColorButton = blueButton;
                        temp.Color = Color.Blue;
                    }
                    else if (splittedLine[5] == "Green")
                    {
                        temp.ColorButton = greenButton;
                        temp.Color = Color.Green;
                    }
                    else if (splittedLine[5] == "Orange")
                    {
                        temp.ColorButton = orangeButton;
                        temp.Color= Color.Orange;
                    }
                    else if (splittedLine[5] == "Black")
                    {
                        temp.ColorButton = blackButton;
                        temp.Color = Color.Black;
                    }
                    else if (splittedLine[5] == "Yellow")
                    {
                        temp.ColorButton = yellowButton;
                        temp.Color = Color.Yellow;
                    }
                    else if (splittedLine[5] == "Purple")
                    {
                        temp.ColorButton = purpleButton;
                        temp.Color = Color.Purple;
                    }
                    else if (splittedLine[5] == "White")
                    {
                        temp.ColorButton = whiteButton;
                        temp.Color = Color.White;
                    }

                    Bitmap bmp = new Bitmap(temp.Size.Width, temp.Size.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                    }
                    temp.Image = bmp;
                    using (Graphics g = Graphics.FromImage(temp.Image))
                    {
                        temp.DrawShape(temp.Color, temp.Size.Width, temp.Size.Height, g);
                    }
                    temp.Refresh();

                    paintArea.Controls.Add(temp);
                    shapeList.Add(temp);
                }
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog outputFileDialog = new SaveFileDialog();
            outputFileDialog.Reset();
            outputFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            outputFileDialog.Filter = "Metin Belgesi Dosyası | *.txt";
            outputFileDialog.OverwritePrompt = false;
            outputFileDialog.CreatePrompt = true;
            String str = new string(new char[] { });

            if (outputFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                using (StreamWriter output = new StreamWriter(outputFileDialog.FileName))
                {
                    foreach (var shape in shapeList)
                    {
                        str = shape.ShapeName + " " + shape.Location.X + " " + shape.Location.Y + " " + shape.Size.Width + " " + shape.Size.Height + " " + shape.Color.Name;
                        output.WriteLine(str);
                    }
                }
            }

        }
    }
}