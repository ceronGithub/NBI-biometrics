using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBI
{
    internal class AutomaticFileReallocation
    {
        public string LeftFingerPrint(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - LEFTFINGER" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - LEFTFINGER" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string RightFingerPrint(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - RIGHTFINGER" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - RIGHTFINGER" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string LeftThumbPrint(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - LEFTTHUMB" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - LEFTTHUMB" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }

        public string RightThumbPrint(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - RIGHTTHUMB" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - RIGHTTHUMB" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }

        public string LeftEye(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - LEFTEYE" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - LEFTYEYE" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string RightEye(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - RIGHTEYE" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - RIGHTEYE" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string Document(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - DOCUMENT" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - DOCUMENT" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string ID(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - ID" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - ID" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
        public string SIGNATURE(string personFname, string personLname, string filepath, string folderdestination, string extension)
        {
            try
            {
                if (personFname != string.Empty && personLname != string.Empty)
                {
                    File.Copy(filepath, folderdestination + "\\" + (personFname + personLname) + " - SIGNATURE" + extension);
                    //StreamWriter createFile = new StreamWriter(@""+ folderpath + "\\" + (personFname, personLname) + fileextension);                    
                    return (folderdestination + "\\" + (personFname + personLname) + " - SIGNATURE" + extension);
                }
                else
                {
                    return "Missing";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("File already existing.");
                return "Missing";
            }
        }
    }
}
