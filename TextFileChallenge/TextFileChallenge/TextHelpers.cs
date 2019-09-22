using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    static class TextHelpers
    {
        /// <summary>
        /// Returns full path to file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>String containing full file path.</returns>
        public static string FullFilePath(this string fileName)
        {
            string pathToCSVFiles = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            return pathToCSVFiles + "\\" + fileName;

            // This can be used to get a path from App.config file.
            //return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        /// <summary>
        /// Returns all the lines from CSV file.
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <returns>List of strings containing all lines from file.</string></returns>
        public static List<string> GetFileData(this string fullFilePath)
        {
            if (!File.Exists(fullFilePath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(fullFilePath).ToList();
        }

        /// <summary>
        /// Converts data from a List of strings to a BindingList of UserModels.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>BindingList of UserModels.</returns>
        public static BindingList<UserModel> ConvertToUserModels(this List<string> lines)
        {
            BindingList<UserModel> users = new BindingList<UserModel>();

            string[] columnNames = lines[0].Split(',');

            for (int i = 1; i < lines.Count(); i++)
            {
                string[] columnData = lines[i].Split(',');

                UserModel u = AssignDataToUserModel(columnNames, columnData);

                users.Add(u);
            }

            return users;
        }

        /// <summary>
        /// Saves data to file in CSV format.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="fileName"></param>
        public static void SaveToUsersFile(this BindingList<UserModel> users, string fileName)
        {
            List<string> lines = new List<string>();

            string firstLine = File.ReadLines(fileName.FullFilePath()).First();
            string[] columnNames = firstLine.Split(',');

            lines.Add(firstLine);

            foreach (UserModel u in users)
            {
                lines.Add(u.ReturnFormattedRow(columnNames));
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }



        //
        // Private Methods
        //

        /// <summary>
        /// Returns a correctly formatted comma-separated row of data.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="colNames"></param>
        /// <returns>Returns a string containing a row of comma-separated data.</returns>
        private static string ReturnFormattedRow(this UserModel u, string[] colNames)
        {
            string tempLine = "";

            for (int index = 0; index < colNames.Count(); index++)
            {
                switch (colNames[index])
                {
                    case "FirstName":
                        tempLine += u.FirstName + ",";
                        break;
                    case "LastName":
                        tempLine += u.LastName + ",";
                        break;
                    case "Age":
                        tempLine += u.Age + ",";
                        break;
                    case "IsAlive":
                        string aliveStatus = "0,";
                        if (u.IsAlive)
                        {
                            aliveStatus = "1,";
                        }
                        tempLine += aliveStatus;
                        break;
                    default:
                        throw new Exception($"The column \"{ colNames[index] }\" should not be part of the csv file.");
                }
            }

            return tempLine.TrimEnd(','); // remove the trailing comma
        }

        /// <summary>
        /// Correctly assigns data from a comma-separated line of data to the UserModel object.
        /// </summary>
        /// <param name="colNames">String array of column names.</param>
        /// <param name="colData">String array of a row of data.</param>
        /// <returns>UserModel object with assigned attributes.</returns>
        private static UserModel AssignDataToUserModel(string[] colNames, string[] colData)
        {
            UserModel u = new UserModel();

            for (int i = 0; i < colNames.Count(); i++)
            {
                switch (colNames[i])
                {
                    case "FirstName":
                        u.FirstName = colData[i];
                        break;
                    case "LastName":
                        u.LastName = colData[i];
                        break;
                    case "Age":
                        u.Age = int.Parse(colData[i]);
                        break;
                    case "IsAlive":
                        u.IsAlive = Convert.ToBoolean(int.Parse(colData[i]));
                        break;
                    default:
                        throw new Exception($"The column \"{ colNames[i] }\" should not be part of the csv file.");
                }
            }

            return u;
        }
    }
}
