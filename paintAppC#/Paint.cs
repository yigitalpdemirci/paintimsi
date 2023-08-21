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
        Dictionary<string, (Button, Color)> ColorButtonMap;
        Dictionary<string, Button> ShapeButtonMap;
        List<Button> ShapeButtonList, ColorButtonList, ModeButtonList;
        public Paint()
        {
            InitializeComponent();

            ShapeButtonList = new List<Button> { rectangleButton, triangleButton, circleButton, hexagonButton};
            ColorButtonList = new List<Button> { redButton, blueButton, greenButton, orangeButton, blackButton, yellowButton, purpleButton, whiteButton};
            ModeButtonList =  new List<Button> { selectButton, deleteButton, clearBoardButton};

            ColorButtonMap = new Dictionary<string, (Button, Color)>
            {
                { "Red", (redButton, Color.Red)},
                { "Blue", (blueButton, Color.Blue)},
                { "Green", (greenButton, Color.Green)},
                { "Orange", (orangeButton, Color.Orange)},
                { "Black", (blackButton, Color.Black)},
                { "Yellow", (yellowButton, Color.Yellow)},
                { "Purple", (purpleButton,  Color.Purple)},
                { "White", (whiteButton, Color.White)}
            };
            ShapeButtonMap = new Dictionary<string, Button>
            {
                { "Rectangle", rectangleButton },
                { "Triangle", triangleButton },
                { "Ellipse", circleButton },
                { "Hexagon", hexagonButton }
            };
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
            List<Button> DeselectedButtons = new List<Button>();
            DeselectedButtons.AddRange(ModeButtonList);

            switch (buttonType)
            {
                case "Shape":
                    DeselectedButtons.AddRange(ShapeButtonList);
                    break;
                case "Color":
                    DeselectedButtons.AddRange(ColorButtonList);
                    break;
                case "Mode":
                    DeselectedButtons.AddRange(ShapeButtonList);
                    DeselectedButtons.AddRange(ColorButtonList);
                    break;
            }

            foreach (Button b in DeselectedButtons) 
            {
                b.FlatStyle = FlatStyle.Standard;
            }

            if (selectedButton != null)
            {
                selectedButton.FlatStyle = FlatStyle.Flat;
            }
        }

        private void deselectOtherButtons(String buttonType, Button[] buttons)
        {
            deselectOtherButtons(buttonType, buttons[0]);
            buttons[1].FlatStyle = FlatStyle.Flat;
        }

        // Shape class (Inherits pictureBox) Using encapsulation and abstraction.

        private abstract class Shape : PictureBox
        {
            private bool isMoving;
            private Point lastLocation;

            public Shape(int x, int y, int xLength, int yLength, Color color, Graphics g)
            {
                this.X = x;
                this.Y = y;
                this.XLength = xLength;
                this.YLength = yLength;
                this.Color = color;

                MouseDown += Shape_MouseDown;
                MouseMove += Shape_MouseMove;
                MouseUp += Shape_MouseUp;
            }

            public Shape(string ShapeName, Button ShapeButton, int X, int Y, Point Location, Size Size, PictureBoxSizeMode SizeMode)
            {
                this.ShapeName = ShapeName;
                this.ShapeButton = ShapeButton;
                this.X = X;
                this.Y = Y;
                this.Location = Location;
                this.Size = Size;
                this.SizeMode = SizeMode;

                MouseDown += Shape_MouseDown;
                MouseMove += Shape_MouseMove;
                MouseUp += Shape_MouseUp;
            }

            public String ShapeName { get; set;}
            
            public int X { get; set;}

            public int Y { get; set;}

            public int XLength { get; set;}

            public int YLength { get; set;}

            public Color Color { get; set;}

            public Button ColorButton { get; set;}

            public Button ShapeButton { get; set;}

            internal abstract void DrawShape(Color color, int width, int height, Graphics g);

            internal void ChangeColor(Color color)
            {
                this.Color = color;
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
                    //Button[] SelectedShapesButtons = new Button[2];
                    //if(ShapeButtonMap.TryGetValue(this.ShapeName, out var ButtonTuple))
                    //{
                    //    SelectedShapesButtons[0] = ButtonTuple.Item1;
                    //}
                    //if(ColorButtonMap.TryGetValue(this.Color.ToString(), out var ColorTuple))
                    //{
                    //    SelectedShapesButtons[1] = ColorTuple.Item1;
                    //}
                    //deselectOtherButtons("Mode",SelectedShapesButtons);
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

            public Rectangle(string ShapeName, Button ShapeButton, int X, int Y, Point Location, Size Size, PictureBoxSizeMode SizeMode) : base(ShapeName, ShapeButton, X, Y, Location, Size, SizeMode)
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

            public Triangle(string ShapeName, Button ShapeButton, int X, int Y, Point Location, Size Size, PictureBoxSizeMode SizeMode) : base(ShapeName, ShapeButton, X, Y, Location, Size, SizeMode)
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

            public Ellipse(string ShapeName, Button ShapeButton, int X, int Y, Point Location, Size Size, PictureBoxSizeMode SizeMode) : base(ShapeName, ShapeButton, X, Y, Location, Size, SizeMode)
            {

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

            public Hexagon(string ShapeName, Button ShapeButton, int X, int Y, Point Location, Size Size, PictureBoxSizeMode SizeMode) : base(ShapeName, ShapeButton, X, Y, Location, Size, SizeMode)
            {

            }

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

        //Main function for color button click
        private void ColorClickFunction(Button buttonName, Color colorName)
        {
            deselectOtherButtons("Color", buttonName);
            if(mode == Mode.Select && currentPictureBox != null)
            {
                currentPictureBox.ChangeColor(colorName);
            }
            currentColor = colorName;
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(redButton, Color.Red);
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(blueButton, Color.Blue);
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(greenButton, Color.Green);
        }

        private void orangeButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(orangeButton, Color.Orange);
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(blackButton, Color.Black);
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(yellowButton, Color.Yellow);
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(purpleButton, Color.Purple);
        }

        private void whiteButton_Click(object sender, EventArgs e)
        {
            ColorClickFunction(whiteButton, Color.White);
        }

        private void ModeClickFunction(Button buttonName, Mode modeName)
        {
            deselectOtherButtons("Mode", buttonName);
            isDrawing = false;
            mode = modeName;
            currentPictureBox = null;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            ModeClickFunction(selectButton, Mode.Select);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            ModeClickFunction(deleteButton, Mode.Delete);
        }

        private void clearBoardButton_Click(object sender, EventArgs e)
        {
            ModeClickFunction(clearBoardButton, Mode.Select);
            paintArea.Controls.Clear();
            shapeList.Clear();
        }
        private void paintArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode == Mode.Select || mode == Mode.Delete || currentColor.Name == "0")
            {
                return;
            }

            isDrawing = true;
            startPoint = e.Location;

            Shape temp = mode switch
            {
                Mode.Rectangle => new Rectangle("Rectangle", rectangleButton, startPoint.X, startPoint.Y, startPoint, new Size(10, 10), PictureBoxSizeMode.CenterImage),
                Mode.Triangle => new Triangle("Triangle", triangleButton, startPoint.X, startPoint.Y, startPoint, new Size(10, 10), PictureBoxSizeMode.CenterImage),
                Mode.Circle => new Ellipse("Ellipse", circleButton, startPoint.X, startPoint.Y, startPoint, new Size(10, 10), PictureBoxSizeMode.CenterImage),
                Mode.Hexagon => new Hexagon("Hexagon", hexagonButton, startPoint.X, startPoint.Y, startPoint, new Size(10, 10), PictureBoxSizeMode.CenterImage),
                _ => throw new ArgumentException("Hatali Arguman.")
            };
            temp.Color = currentColor;

            if (ColorButtonMap.TryGetValue(currentColor.ToString(), out var ColorTuple))
            {
                temp.ColorButton = ColorTuple.Item1;
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
            if (mode == Mode.Select || mode == Mode.Delete || currentColor.Name == "0")
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
                    int tempX = Int32.Parse(splittedLine[1]);
                    int tempY = Int32.Parse(splittedLine[2]);
                    Shape temp = splittedLine[0] switch
                    {
                        "Rectangle" => new Rectangle(splittedLine[0], rectangleButton, tempX, tempY, new Point(tempX, tempY), new Size(Int32.Parse(splittedLine[3]), Int32.Parse(splittedLine[4])), PictureBoxSizeMode.CenterImage),
                        "Triangle" => new Triangle(splittedLine[0], triangleButton, tempX, tempY, new Point(tempX, tempY), new Size(Int32.Parse(splittedLine[3]), Int32.Parse(splittedLine[4])), PictureBoxSizeMode.CenterImage),
                        "Ellipse" => new Ellipse(splittedLine[0], circleButton, tempX, tempY, new Point(tempX, tempY), new Size(Int32.Parse(splittedLine[3]), Int32.Parse(splittedLine[4])), PictureBoxSizeMode.CenterImage),
                        "Hexagon" => new Hexagon(splittedLine[0], hexagonButton, tempX, tempY, new Point(tempX, tempY), new Size(Int32.Parse(splittedLine[3]), Int32.Parse(splittedLine[4])), PictureBoxSizeMode.CenterImage),
                        _ => throw new ArgumentException("Hatali Arguman")
                    };
                    
                    if (ColorButtonMap.TryGetValue(splittedLine[5], out var colorTuple))
                    {
                        temp.ColorButton = colorTuple.Item1;
                        temp.Color = colorTuple.Item2;
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
                        str = $"{shape.ShapeName} {shape.Location.X} {shape.Location.Y} {shape.Size.Width} {shape.Size.Height} {shape.Color.Name}";
                        output.WriteLine(str);
                    }
                }
            }

        }
    }
}