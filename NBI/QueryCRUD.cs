using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Security.Policy;

namespace NBI
{
    internal class QueryCRUD
    {
        string connetionString = "Server=localhost;database=ht_iris;uid=root;pwd=password;";
        //string connetionString = "Server=localhost;database=ht_iris;uid=root;pwd=;";

        public bool testConnection()
        {
            MySqlConnection sqlConnection = new MySqlConnection();
            sqlConnection.ConnectionString = connetionString;
            try
            {
                sqlConnection.Open();
                //MessageBox.Show("Connection Open ! ");
                return true;
                sqlConnection.Close();                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Can not open connection ! ");
                return false;
            }
        }
        public string updateUserInformation(string ID, string FNAME, string MNAME, string LNAME, string SNAME, string BIRTHDATE, string SEX, string ADDRESS, string CITY, string BARANGAY, string ZIPCODE, string LEFTFINGER, string RIGHTFINGER, string LEFTTHUMB, string RIGHTTHUMB, string LEFTEYE, string RIGHTEYE, string DOCUMENT, string IDPICTURE, string SIGNATURE)
        {
            string query = "UPDATE users SET firstname=@fname, middlename=@mname, lastname=@lname, suffixname=@sname, dateofbirth=@bday, sex=@sex, address=@address, municipality=@municipal, barangay=@brgy, zipcode=@zip, filefingerprintleft=@leftfinger, filefingerprintright=@rightfinger, filethumbprintleft=@thumbleft, filethumbprintright=@thumbright, fileirisleft=@lefteye, fileirisright=@righteye, filedocument=@doc, fileidpicture=@idpic, filesignature=@signature WHERE id=@id";
            using (MySqlConnection conn = new MySqlConnection(connetionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", ID);
                    command.Parameters.AddWithValue("@fname", FNAME);
                    command.Parameters.AddWithValue("@mname", MNAME);
                    command.Parameters.AddWithValue("@lname", LNAME);
                    command.Parameters.AddWithValue("@sname", SNAME);
                    command.Parameters.AddWithValue("@sex", SEX);
                    command.Parameters.AddWithValue("@bday", DateTime.Parse(BIRTHDATE));
                    command.Parameters.AddWithValue("@address", ADDRESS);
                    command.Parameters.AddWithValue("@municipal", CITY);
                    command.Parameters.AddWithValue("@brgy", BARANGAY);
                    command.Parameters.AddWithValue("@zip", ZIPCODE);
                    command.Parameters.AddWithValue("@leftfinger", LEFTFINGER);
                    command.Parameters.AddWithValue("@rightfinger", RIGHTFINGER);
                    command.Parameters.AddWithValue("@thumbleft", LEFTTHUMB);
                    command.Parameters.AddWithValue("@thumbright", RIGHTTHUMB);
                    command.Parameters.AddWithValue("@lefteye", LEFTEYE);
                    command.Parameters.AddWithValue("@righteye", RIGHTEYE);
                    command.Parameters.AddWithValue("@doc", DOCUMENT);
                    command.Parameters.AddWithValue("@idpic", IDPICTURE);
                    command.Parameters.AddWithValue("@signature", SIGNATURE);
                    
                    /*
                    conn.Open();
                    command.ExecuteNonQuery();
                    return "success";
                    conn.Close();
                    */
                    
                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        return "success";
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        return "fail";
                    }                    
                }
            }
        }
        public string CheckIfUserIsExisting(string FNAME, string MNAME, string LNAME, string SNAME, string SEX, string BIRTHDATE, string ADDRESS, string CITY, string BARANGAY, string ZIPCODE)
        {
            //MessageBox.Show(FNAME + "\n" + MNAME + "\n" + LNAME + "\n" + SNAME + "\n" + SEX + "\n" + BIRTHDATE + "\n" + ADDRESS);            
            //string query = "SELECT * FROM users WHERE firstname = \"@fname\" AND middlename = \"@mname\" AND lastname = \"@lname\" AND suffixname = \"@sname\" AND dateofbirth = @bday AND sex = \"@sex\" AND address = \"@address\"";
            string query = "SELECT * FROM users WHERE firstname = @fname AND middlename = @mname AND lastname = @lname AND suffixname = @sname AND dateofbirth = @bday AND sex = @sex AND address = @address AND municipality = @municipal AND barangay = @brgy AND zipcode = @zip";
            using (MySqlConnection conn = new MySqlConnection(connetionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@fname", FNAME);
                    command.Parameters.AddWithValue("@mname", MNAME);
                    command.Parameters.AddWithValue("@lname", LNAME);
                    command.Parameters.AddWithValue("@sname", SNAME);
                    command.Parameters.AddWithValue("@bday", BIRTHDATE);
                    command.Parameters.AddWithValue("@sex", SEX);
                    command.Parameters.AddWithValue("@address", ADDRESS);
                    command.Parameters.AddWithValue("@municipal", CITY);
                    command.Parameters.AddWithValue("@brgy", BARANGAY);
                    command.Parameters.AddWithValue("@zip", ZIPCODE);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        //MessageBox.Show("existing");
                        return "existing";
                    }
                    else
                    {
                        //MessageBox.Show("not-existing");
                        return "not-existing";
                    }
                }
                conn.Close();
            }
        }
        public string InsertRecord(string FNAME, string MNAME, string LNAME, string SNAME, string SEX, string BIRTHDATE, string ADDRESS, string CITY, string BARANGAY, string ZIPCODE, string LEFTHAND, string RIGHTHAND , string LEFTTHUMB, string RIGHTTHUMB, string LEFTEYE, string RIGHTEYE, string DOCUMENT, string ID, string SIGNATURE)
        {
            //MessageBox.Show(FNAME + "\n" + MNAME + "\n" + LNAME + "\n" + SNAME + "\n" + SEX + "\n" + BIRTHDATE + "\n" + ADDRESS + "\n" + CITY + "\n" + BARANGAY + "\n" + ZIPCODE + "\n" + LEFTHAND + "\n" + RIGHTHAND + "\n" + LEFTTHUMB + "\n" + RIGHTTHUMB + "\n" + LEFTEYE + "\n" + RIGHTEYE + "\n" + DOCUMENT + "\n" + ID + "\n" + SIGNATURE);
            // checks all input field.
            if (FNAME != null && MNAME != null && LNAME != null && SNAME != null && SEX != null && BIRTHDATE != null && ADDRESS != null && RIGHTHAND != "Missing" && LEFTHAND != "Missing" && RIGHTEYE != "Missing" && LEFTEYE != "Missing" && DOCUMENT != "Missing" && ID != "Missing" && RIGHTTHUMB != "Missing" && LEFTTHUMB != "Missing")
            {
                string query = "INSERT into users (firstname,middlename,lastname,suffixname,dateofbirth,sex,address,municipality,barangay,zipcode, filefingerprintleft, filefingerprintright, filethumbprintleft, filethumbprintright, fileirisleft, fileirisright, filedocument, fileidpicture, filesignature) VALUES (@firstname, @middlename, @lastname, @suffixname, @dateofbirth, @sex, @address, @municipal, @brgy, @zip, @lefthand, @righthand, @leftthumb, @rightthumb , @lefteye, @righteye, @document, @id, @signature)";
                using (MySqlConnection conn = new MySqlConnection(connetionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@firstname", FNAME);
                        command.Parameters.AddWithValue("@middlename", MNAME);
                        command.Parameters.AddWithValue("@lastname", LNAME);
                        command.Parameters.AddWithValue("@suffixname", SNAME);
                        command.Parameters.AddWithValue("@dateofbirth", BIRTHDATE);
                        command.Parameters.AddWithValue("@sex", SEX);
                        command.Parameters.AddWithValue("@address", ADDRESS);
                        command.Parameters.AddWithValue("@municipal", CITY);
                        command.Parameters.AddWithValue("@brgy", BARANGAY);
                        command.Parameters.AddWithValue("@zip", ZIPCODE);
                        command.Parameters.AddWithValue("@lefthand", LEFTHAND);
                        command.Parameters.AddWithValue("@righthand", RIGHTHAND);
                        command.Parameters.AddWithValue("@leftthumb", LEFTTHUMB);
                        command.Parameters.AddWithValue("@rightthumb", RIGHTTHUMB);
                        command.Parameters.AddWithValue("@lefteye", LEFTEYE);
                        command.Parameters.AddWithValue("@righteye", RIGHTEYE);
                        command.Parameters.AddWithValue("@document", DOCUMENT);
                        command.Parameters.AddWithValue("@id", ID);
                        command.Parameters.AddWithValue("@signature", SIGNATURE);
                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            return "success";
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            // if fail : return string fail
                            return "fail";
                        }
                    }
                }
            }
            else
            {
                return "fail";
            }
        }
    }
}
