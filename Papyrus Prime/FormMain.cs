using System.IO;//Add this to allow for file input and output
namespace Papyrus_Prime
{
    public partial class FormMain : Form
    {
        //Question marks added to declare the field as nullable
        private OpenFileDialog? ofd; //Declare variable for use later
        private SaveFileDialog? sfd; //Declare variable for use later
        private string? currentFilePath; //Declare variable for use later
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog(); //Create new OpenFileDialog object
            sfd = new SaveFileDialog(); //Create new SaveFileDialog object
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Exit Application
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxMain.Text = ""; //Clear field
            toolStripStatusLabelFileName.Text = ""; //Clear field
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                richTextBoxMain.Text = ""; //clear rich text box
                ofd = new OpenFileDialog(); //Create new OpenFileDialog Object
                ofd.InitialDirectory = @"C:\txt";//set initial directory for OpenFileDialog Object
                ofd.Title = "Browse Text Files Only";//set title of OpenFileDialog Object
                ofd.Filter = "Text Files Only (*.txt) | *.txt";//set a filter for OpenFileDialog Object
                ofd.DefaultExt = "txt";//Set default extension to txt
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var fileLocation = File.ReadAllLines(ofd.FileName); //get file location of declared file name
                    List<string> lines = new List<string>(fileLocation);//create a new list object to hold contents of txt document
                    for (int i = 0; i < lines.Count; i++)//Fill Rich Text Box with contents of txt file
                    {
                        richTextBoxMain.Text += lines[i];//write 1 line of text
                        richTextBoxMain.Text += "\n";//move to next line in preperation for next line to be written
                    }
                    toolStripStatusLabelFileName.Text = "File Name: " + Path.GetFileName(ofd.FileName);//Set StatusLabelFileName to the file name currently open
                }
            }
            catch (Exception ex)//catch exception value
            {
                MessageBox.Show(ex.Message);//display exception value
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd != null) //if savefiledialog object is not null, continue
            {
                try
                {
                    sfd = new SaveFileDialog();//create new object of savefiledialog
                    using (sfd)//use said object to execute the following
                    {
                        sfd.Filter = "Text Files Only (.txt) | *.txt";//set filter for SaveFileDialog Object
                        sfd.AddExtension = true;// Adds extension if omitted from file name for SaveFileDialog Object
                        sfd.DefaultExt = "txt";//set default extension for SaveFileDialog Object to txt
                        sfd.FileName = "";//clear initial File Name for SaveFileDialog Object
                        sfd.ShowDialog();//show dialog box for SaveFileDialog Object
                        currentFilePath = sfd.FileName;//set current file path for use later if user decides to save only, instead of save as.
                        TextWriter tw = new StreamWriter(currentFilePath);//create a new textwriter and give it the location of the desired file to write
                        tw.Write(richTextBoxMain.Text);//write contents of rich text box main to file
                        tw.Close();//close file
                    }
                }
                catch (Exception ex)//catch exception value
                {
                    MessageBox.Show(ex.Message);//display exception value
                }
            }
            
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null)//execute only if currentfilepath is not null.
            {
                try
                {
                    TextWriter tw = new StreamWriter(currentFilePath);//create a new textwriter object with the given file path. to be used if file is already open
                    tw.Write(richTextBoxMain.Text);//write contents of richtextboxmain to file
                    tw.Close();//close file
                }
                catch (Exception ex)//catch exception value
                {
                    MessageBox.Show(ex.Message);//display exception value
                }
            }
            else 
            {
                if (sfd != null) //if savefiledialog object is not null, continue
                {
                    try
                    {
                        sfd = new SaveFileDialog();//create new object of savefiledialog
                        using (sfd)//use said object to execute the following
                        {
                            sfd.Filter = "Text Files Only (.txt) | *.txt";//set filter for SaveFileDialog Object
                            sfd.AddExtension = true;// Adds extension if omitted from file name for SaveFileDialog Object
                            sfd.DefaultExt = "txt";//set default extension for SaveFileDialog Object to txt
                            sfd.FileName = "";//clear initial File Name for SaveFileDialog Object
                            sfd.ShowDialog();//show dialog box for SaveFileDialog Object
                            currentFilePath = sfd.FileName;//set current file path for use later if user decides to save only, instead of save as.
                            TextWriter tw = new StreamWriter(currentFilePath);//create a new textwriter and give it the location of the desired file to write
                            tw.Write(richTextBoxMain.Text);//write contents of rich text box main to file
                            tw.Close();//close file
                        }
                    }
                    catch (Exception ex)//catch exception value
                    {
                        MessageBox.Show(ex.Message);//display exception value
                    }
                }
            }
            
        }
    }
}
