﻿using MyConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MyConversion
{
    public static class ForIEnumarable
    {
        public static IEnumerable<TResult> SuperZip<T, TResult>(this IEnumerable<T> source, Func<T[], TResult> func, params IEnumerable<T>[] other)
        {
                var enumList = other.Select(i => i.GetEnumerator()).ToList();
                enumList.Insert(0, source.GetEnumerator());
                {
                    while (enumList.All(i=>i.MoveNext()))
                        yield return func(enumList.Select(i=>i.Current).ToArray());
                }
                enumList.ForEach(i => i.Dispose());           
        }
        public static IEnumerable<TResult> ZipThree<T1, T2, T3, TResult>(
        this IEnumerable<T1> source,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        Func<T1, T2, T3, TResult> func)
        {
            using (var e1 = source.GetEnumerator())
            using (var e2 = second.GetEnumerator())
            using (var e3 = third.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext())
                    yield return func(e1.Current, e2.Current, e3.Current);
            }
        }
    }
    public static class ForStrings
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                return new List<int>();
                //throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
    public class TimeConverter
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static double DateTimeToUnixTimeStamp(DateTime dtDateTime)
        {
            return dtDateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }

}

namespace MIAnalyzer
{
    class TrialSequence
    {
        public TrialSequence()
        {
            this.GUID = Guid.NewGuid().ToString();
        }
        public void LoadMetaData(MetaData metaData)
        {
            this.User = metaData.User;
            this.PassPhrase = metaData.PassPhrase;
            this.dateTime = metaData.dateTime;
        }
        public void LoadMotionData(MotionData motionData)
        {
            this.Motion_UnixTime = motionData.Motion_UnixTime;
            this.Motion_ACCX = motionData.Motion_ACCX;
            this.Motion_ACCY = motionData.Motion_ACCY;
            this.Motion_ACCZ = motionData.Motion_ACCZ;
            this.Motion_WX = motionData.Motion_WX;
            this.Motion_WY = motionData.Motion_WY;
            this.Motion_WZ = motionData.Motion_WZ;
        }
        public void LoadKeyLoggerData(KeyLoggerData keyLoggerData)
        {
            this.KeyLogger_IsKeyDown = keyLoggerData.KeyLogger_IsKeyDown;
            this.KeyLogger_UnixTime = keyLoggerData.KeyLogger_UnixTime;
            this.KeyLogger_Key = keyLoggerData.KeyLogger_Key;
        }
        public string GUID { get; }
        public string User { get; set; }
        public string PassPhrase { get; set; }
        public DateTime dateTime { get; set; }
        public List<double> Motion_UnixTime { get; set; }
        public List<double> Motion_ACCX { get; set; }
        public List<double> Motion_ACCY { get; set; }
        public List<double> Motion_ACCZ { get; set; }
        public List<double> Motion_WX { get; set; }
        public List<double> Motion_WY { get; set; }
        public List<double> Motion_WZ { get; set; }
        public List<double> KeyLogger_UnixTime { get; set; }
        public List<bool> KeyLogger_IsKeyDown { get; set; }
        public List<char> KeyLogger_Key { get; set; }
        public List<Trial> GetTrials(bool AddExtraMD = false)
        {
            var startDelta = 1000;
            var endDelta = 1000;
            var res = new List<Trial>();
            var pressedchars = from t in this.KeyLogger_Key.Zip(this.KeyLogger_IsKeyDown.Zip(this.KeyLogger_UnixTime, (a, b) => Tuple.Create(a, b)), (i, j) => Tuple.Create(i, j.Item1, j.Item2)) where (t.Item2 == true) select t;
            var strPressedChars = (new StringBuilder()).Append(pressedchars.Select(i=>i.Item1).ToArray()).ToString();
            //Parsing is not key-sensitive
            var indexes = (Program._USEHARDCODE)?strPressedChars.ToUpper().AllIndexesOf(this.PassPhrase.ToUpper())
                :strPressedChars.AllIndexesOf(this.PassPhrase);
            for (int ind =0;ind<indexes.Count;ind++)
            {
                var index = indexes[ind];
                var trial = new Trial();
                trial.TrialNumber = ind;
                trial.LoadDataFromTrialSeq(this);
                trial.intLoggerStartRowNum = this.KeyLogger_UnixTime.IndexOf(pressedchars.ToList()[index].Item3);
                trial.intLoggerEndRowNum = trial.intLoggerStartRowNum + 2 * this.PassPhrase.Length - 1;
                if (this.KeyLogger_UnixTime.Count <= trial.intLoggerEndRowNum)
                    continue;
                var dStartLogTime = this.KeyLogger_UnixTime[trial.intLoggerStartRowNum] - ((AddExtraMD) ? startDelta : 0);
                var dEndLogTime = this.KeyLogger_UnixTime[trial.intLoggerEndRowNum] + ((AddExtraMD) ? endDelta : 0);
                //Now lets find these times in Motion Data
                double dStartMotionTime, dEndMotionTime;
                try
                {
                    dStartMotionTime = this.Motion_UnixTime.Last(i => i < dStartLogTime);
                }
                catch
                {
                    dStartMotionTime = this.Motion_UnixTime[0];
                }
                try
                {
                    dEndMotionTime = this.Motion_UnixTime.First(i => i > dEndLogTime);
                }
                catch
                {
                    dEndMotionTime = this.Motion_UnixTime.Last();
                }
                trial.intMotionStartRowNum = this.Motion_UnixTime.IndexOf(dStartMotionTime);
                trial.intMotionEndRowNum = this.Motion_UnixTime.IndexOf(dEndMotionTime);
                res.Add(trial);
            }
            return res;
        }
        static public List<Trial> ParseTrials(TrialSequence trialSequence)
        {
            return trialSequence.GetTrials();
            //you should copy function from above because this func is not last version of one
            throw new NotImplementedException();
            var res = new List<Trial>();
            var pressedchars = from t in trialSequence.KeyLogger_Key.Zip(trialSequence.KeyLogger_IsKeyDown.Zip(trialSequence.KeyLogger_UnixTime, (a, b) => Tuple.Create(a, b)), (i, j) => Tuple.Create(i, j.Item1, j.Item2)) where (t.Item2 == true) select t;
            var indexes = (new StringBuilder()).Append(pressedchars.ToArray()).ToString().AllIndexesOf(trialSequence.PassPhrase);
            foreach (var index in indexes)
            {
                var trial = new Trial();
                trial.LoadDataFromTrialSeq(trialSequence);
                trial.intLoggerStartRowNum = trialSequence.KeyLogger_UnixTime.IndexOf(pressedchars.ToList()[index].Item3);
                trial.intLoggerEndRowNum = trial.intLoggerStartRowNum + 2 * trialSequence.PassPhrase.Length - 1;
                var dStartLogTime = trialSequence.KeyLogger_UnixTime[trial.intLoggerStartRowNum];
                var dEndLogTime = trialSequence.KeyLogger_UnixTime[trial.intLoggerEndRowNum];
                var dStartMotionTime = trialSequence.Motion_UnixTime.Last(i => i < dStartLogTime);
                var dEndMotionTime = trialSequence.Motion_UnixTime.First(i => i > dEndLogTime);
                trial.intMotionStartRowNum = trialSequence.Motion_UnixTime.IndexOf(dStartMotionTime);
                trial.intMotionEndRowNum = trialSequence.Motion_UnixTime.IndexOf(dEndMotionTime);
                //trial.KeyLogger_IsKeyDown = trialSequence.KeyLogger_IsKeyDown.GetRange(trial.intLoggerStartRowNum, trial.intLoggerEndRowNum - trial.intLoggerStartRowNum);

                res.Add(trial);
            }
            return res;
        }
    }
    [Serializable]
    class Trial:TrialSequence
    {
        public string SequenceGUID;
        public int TrialNumber;
        public int intLoggerStartRowNum, intLoggerEndRowNum;
        public int intMotionStartRowNum, intMotionEndRowNum;
        public Trial(Trial trial)
        {
            this.LoadDataFromTrialSeq(trial);
            this.SequenceGUID = trial.SequenceGUID;
            this.TrialNumber = trial.TrialNumber;
            this.intLoggerStartRowNum = trial.intLoggerStartRowNum;
            this.intLoggerEndRowNum = trial.intLoggerEndRowNum;
            this.intMotionStartRowNum = trial.intMotionStartRowNum;
            this.intMotionEndRowNum = trial.intMotionEndRowNum;
        }
        public Trial() { }
        public void LoadDataFromTrialSeq(TrialSequence trialSequence)
        {
            this.dateTime = trialSequence.dateTime;
            this.User = trialSequence.User;
            this.PassPhrase = trialSequence.PassPhrase;
            this.SequenceGUID = trialSequence.GUID;
            this.Motion_UnixTime = trialSequence.Motion_UnixTime;
            this.Motion_ACCX = trialSequence.Motion_ACCX;
            this.Motion_ACCY = trialSequence.Motion_ACCY;
            this.Motion_ACCZ = trialSequence.Motion_ACCZ;
            this.Motion_WX = trialSequence.Motion_WX;
            this.Motion_WY = trialSequence.Motion_WY;
            this.Motion_WZ = trialSequence.Motion_WZ;
            this.KeyLogger_IsKeyDown = trialSequence.KeyLogger_IsKeyDown;
            this.KeyLogger_Key = trialSequence.KeyLogger_Key;
            this.KeyLogger_UnixTime = trialSequence.KeyLogger_UnixTime;
        }
        public override string ToString()
        {
            return string.Format("User:{0} Pass:{1} Date:{2} TrialNum: {3}", User, PassPhrase, dateTime.ToLongDateString(), TrialNumber);
        }
        public List<(double, double)> ACCX
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_ACCX);
            }
        }
        public List<(double, double)> ACCY
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_ACCY);
            }
        }
        public List<(double, double)> ACCZ
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_ACCZ);
            }
        }
        public List<(double, double)> WX
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_WX);
            }
        }
        public List<(double, double)> WY
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_WY);
            }
        }
        public List<(double, double)> WZ
        {
            get
            {
                return ExtractMotionDataWithTime(Motion_WZ);
            }
        }
        private List<(double, double)> ExtractMotionDataWithTime(List<double> listY, List<double> listX = null, int intStartIndex=-1, int intEndIndex=-1)
        {
            var res = new List<(double, double)>();
            if (listX == null)
                listX = Motion_UnixTime;
            if (intStartIndex == -1)
                intStartIndex = intMotionStartRowNum;
            if (intEndIndex == -1)
                intEndIndex = intMotionEndRowNum;
            var X = listX.GetRange(intStartIndex, intEndIndex - intStartIndex+1);
            var MinX = X.Min();
            X = X.Select(i => i - MinX).ToList();
            var Y = listY.GetRange(intStartIndex, intEndIndex - intStartIndex+1);
            res = X.Zip(Y, (i, j) => (i, j)).ToList();
            return res;
        }

    }
    struct MetaData
    {
        public string User;
        public string PassPhrase;
        public DateTime dateTime;
    }
    class KeyLoggerData
    {
        public List<double> KeyLogger_UnixTime=new List<double>();
        public List<bool> KeyLogger_IsKeyDown=new List<bool>();
        public List<char> KeyLogger_Key=new List<char>();
    }
    class MotionData
    {
        public List<double> Motion_UnixTime=new List<double>(), Motion_ACCX = new List<double>(), Motion_ACCY = new List<double>(), Motion_ACCZ = new List<double>(), Motion_WX = new List<double>(), Motion_WY = new List<double>(), Motion_WZ = new List<double>();
    }
    class Engine
    {
        //HARDCODE
        DBConnectionParams SQLiteNearEXE = new DBConnectionParams() { DBType = DBType.SQLite, PathToDBFile = System.Windows.Forms.Application.StartupPath + "BSMDB.db" };
        FolderIndexer FI = new FolderIndexer();
        DBController DBC = new DBController();
        /// <summary>
        /// Hardcoded for storing trials in app memory
        /// </summary>
        List<Trial> Trials=new List<Trial>();
        List<TrialSequence> TrialSequences = new List<TrialSequence>();
        public List<Trial> GetTrials()
        {
            if(Program._USEHARDCODE)
            {
                return Trials;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public List<Trial> GetSequences(bool ExportEmpty=true)
        {
            var res = new List<Trial>();
            if (Program._USEHARDCODE)
            {
                foreach(var trialSequence in TrialSequences )
                {
                    var trCount = trialSequence.GetTrials().Count;
                    if (trCount > 0 || ExportEmpty)
                    {
                        var modifiedTrial = new Trial();
                        modifiedTrial.LoadDataFromTrialSeq(trialSequence);
                        modifiedTrial.intMotionStartRowNum = 0;
                        modifiedTrial.intMotionEndRowNum = modifiedTrial.Motion_ACCX.Count - 1;
                        res.Add(modifiedTrial);
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
/*            var trials = GetTrials();
            foreach(var trial in trials)
            {
                foreach(var r in res)
                {
                    if (r.SequenceGUID == trial.SequenceGUID)
                        break;
                }
            }
*/
            return res;
        }
        public List<string> GetTrialsInPythonStyle()
        {
            List<string> res = new List<string>();
            var sbMD = new StringBuilder();
            var sbUsers = new StringBuilder();
            sbMD.Append( "[");
            sbUsers.Append("[");
            var trials = GetTrials();
            foreach(var trial in trials)
            {
                sbMD.Append("[");
                var accx = "[" + string.Join(", ", trial.ACCX.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(accx);
                var accy = "[" + string.Join(", ", trial.ACCY.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(accy);
                var accz = "[" + string.Join(", ", trial.ACCZ.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(accz);
                var wx = "[" + string.Join(", ", trial.WX.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(wx);
                var wy = "[" + string.Join(", ", trial.WY.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(wy);
                var wz = "[" + string.Join(", ", trial.WZ.Select(i => Convert.ToString(i.Item2))) + "], ";
                sbMD.Append(wz);
                sbMD.Append("], ");
                sbUsers.Append(trial.User);
                sbUsers.Append(", ");

            }
            sbMD.Append( "]");
            sbUsers.Append("]");
            res.Add(sbMD.ToString());
            res.Add(sbUsers.ToString());
            return res;
        }
        public List<string> GetTrialsCSV(int Counts, bool GetSequences=false, bool IgnoreCounts = false, bool GetEmptySequences = true)
        {
            if (Counts <= 0)
                IgnoreCounts = true;
            List<string> res = new List<string>();
            char Delimiter = ',';
            var sbMD = new StringBuilder();
            var sbUsers = new StringBuilder();
            var mdHeader = "Number, time(ms), accx(m/s^2), accy, accz, wx(rad/s), wy, wz\r\n";
            var trials = (GetSequences) ? this.GetSequences() : GetTrials();
            foreach (var trial in trials)
            {
                sbMD.Append(mdHeader);
                var currentCounts = (IgnoreCounts) ?trial.ACCX.Count: Counts;
                List<double> preparedUnixTime, preparedACCX, preparedACCY, preparedACCZ, preparedWX, preparedWY, preparedWZ;
                    preparedUnixTime = trial.Motion_UnixTime.Skip(trial.intMotionStartRowNum).Take(currentCounts).ToList();
                    preparedACCX = trial.ACCX.Select(i => i.Item2).Take(currentCounts).ToList();
                    preparedACCY = trial.ACCY.Select(i => i.Item2).Take(currentCounts).ToList();
                    preparedACCZ = trial.ACCZ.Select(i => i.Item2).Take(currentCounts).ToList();
                    preparedWX = trial.WX.Select(i => i.Item2).Take(currentCounts).ToList();
                    preparedWY = trial.WY.Select(i => i.Item2).Take(currentCounts).ToList();
                    preparedWZ = trial.WZ.Select(i => i.Item2).Take(currentCounts).ToList();
                if (Counts > trial.ACCX.Count)
                {
                    preparedUnixTime.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedACCX.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedACCY.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedACCZ.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedWX.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedWY.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                    preparedWZ.AddRange(Enumerable.Repeat(0d, Counts - trial.ACCX.Count));
                }
                var csvMD = preparedACCX.SuperZip(i =>
                  string.Format("{8}{0}{7}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}\r\n", Delimiter, i[0], i[1], i[2], i[3], i[4], i[5], i[6], i[7]),
                  preparedACCY,
                  preparedACCZ,
                  preparedWX,
                  preparedWY,
                  preparedWZ,
                  preparedUnixTime,
                  Enumerable.Range(0, currentCounts).ToList().ConvertAll(i => (double)i)
                    );
                csvMD.All(i => { sbMD.Append(i); return true; });
                sbUsers.Append(string.Format("{1}{0}", Delimiter, trial.User));

            }
            int userCount = sbUsers.ToString().Sum(i => (i == Delimiter) ? 1 : 0);
            var sbUsersHeader = new StringBuilder();
            Enumerable.Range(0, userCount).Select(i => string.Format("username{0}", i+1)).Zip(Enumerable.Repeat(Delimiter, userCount), (i, j) => i + j).All( i => {sbUsersHeader.Append(i); return true; });
            var usersHeader = sbUsersHeader.ToString().TrimEnd(Delimiter)+"\r\n";
            sbUsers.Insert(0,usersHeader);
            res.Add(sbMD.ToString());
            res.Add(sbUsers.ToString());
            return res;
        }
        public Engine()
        {
            if (Program._USEHARDCODE)
            {
                var culture = new CultureInfo("ru-RU");
                culture.NumberFormat.NumberDecimalSeparator = ".";
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
                ConnectToDB();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public void ConnectToDB(DBConnectionParams ConParams)
        {
            DBC.ConnectToDB(ConParams);
        }
        /// <summary>
        /// Use SQLite db near exe in same folder
        /// </summary>
        public void ConnectToDB()
        {
            DBC.ConnectToDB(SQLiteNearEXE);
        }
        FileInfo GetFileInSubFolder(DirectoryInfo Folder, string mask)
        {

            var keyloggerList = Folder.GetFiles(mask);
            if (keyloggerList.Count() != 1)
                return null;
            return keyloggerList[0];
        }
        char DetectCSVDelimiter(List<string> strlst)
        {
            char Delimiter = ',';
            if (strlst[0].Contains(';'))
                Delimiter = ';';
            return Delimiter;
        }
        MetaData ParseMetaDataFile(List<string> strlst, string FileName)
        {
            var res = new MetaData();
            if (!strlst[0].StartsWith("username="))
                throw new NotImplementedException();
            var username = strlst[0].Substring("username=".Length).Trim('\"');
            res.User = username;
            if (!strlst[1].StartsWith("enteredText="))
                throw new NotImplementedException();
            var pass = strlst[1].Substring("enteredText=".Length).Trim('\"');
            res.PassPhrase = pass;
            var timestampStartIndex = FileName.IndexOfAny("0123456789".ToArray());
            var timestampEndIndex = FileName.LastIndexOfAny("0123456789".ToArray());
            var strTimeStamp = (timestampEndIndex - timestampStartIndex > 0)?FileName.Substring(timestampStartIndex, timestampEndIndex - timestampStartIndex+1):"0";
            double dTimeStamp;
            try
            {
                dTimeStamp = Convert.ToDouble(strTimeStamp);
            }
            catch
            {
                dTimeStamp = 0;
            }
            res.dateTime = TimeConverter.UnixTimeStampToDateTime(dTimeStamp);
            return res;
        }
        KeyLoggerData ParseKeyLoggerFile(List<string> strlst)
        {
            var res = new KeyLoggerData();
            var oldFormat = !strlst[0].Contains(',');
            char Delimiter = DetectCSVDelimiter(strlst);
            foreach (var Line in strlst)
            {
                if (!"0123456789".Contains(Line.TrimEnd().Last()))
                    continue;
                string[] fields = Line.Split((oldFormat)?' ':Delimiter);
                bool KeyDown;
                switch (fields[(oldFormat)?0:1][0])
                {
                    case '+':
                        {
                            KeyDown = true;
                            break;
                        }
                    case '-':
                        {
                            KeyDown = false;
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
                var key = (oldFormat) ? fields[1][0] : Convert.ToChar(Convert.ToByte(fields[2]));
                if(Program._USEHARDCODE)
                {
                    if (key == 0)
                    {
                        continue;
                    }
                }
                var time = Convert.ToDouble((oldFormat) ? fields[2].Split('|')[0] : fields[0]);
                //Add Data
                res.KeyLogger_IsKeyDown.Add(KeyDown);
                res.KeyLogger_Key.Add(key);
                res.KeyLogger_UnixTime.Add(time);
            }
            return res;
        }
        MotionData ParseMotionFile(List<string> strlst)
        {
            var res = new MotionData();
            char Delimiter = DetectCSVDelimiter(strlst);
            foreach (var str in strlst)
            {
                if (!"0123456789".Contains(str[0]))
                    continue;
                var splittedStr = str.Split(Delimiter);
                if(splittedStr.Count()>8)
                {
                    throw new NotImplementedException("Stop using delimiter \",\" for double numbers and csv's cells.");
                }
                //Number column support
                if(splittedStr.Count()==8)
                {
                    splittedStr = splittedStr.Skip(1).ToArray();
                }
                res.Motion_UnixTime.Add(Convert.ToDouble(splittedStr[0]));
                res.Motion_ACCX.Add(Convert.ToDouble(splittedStr[1]));
                res.Motion_ACCY.Add(Convert.ToDouble(splittedStr[2]));
                res.Motion_ACCZ.Add(Convert.ToDouble(splittedStr[3]));
                res.Motion_WX.Add(Convert.ToDouble(splittedStr[4]));
                res.Motion_WY.Add(Convert.ToDouble(splittedStr[5]));
                res.Motion_WZ.Add(Convert.ToDouble(splittedStr[6]));
            }
            return res;
        }

        void ProcessNewSubFolder(DirectoryInfo Folder, bool AddExtraMD = false)
        {
            var keyloggerFileInfo = GetFileInSubFolder(Folder, "*keylogger*");
            var motionFileInfo = GetFileInSubFolder(Folder, "*motion*");
            var metadataFileInfo = GetFileInSubFolder(Folder, "*meta*");
            if (keyloggerFileInfo == null || motionFileInfo == null || metadataFileInfo == null)
                return;
            //ReadMetaData
            var strlstMetaData = FileReader.ReadFile(metadataFileInfo.FullName);
            var MetaData = ParseMetaDataFile(strlstMetaData, metadataFileInfo.Name);
            //ReadKeyLoggerFile
            var strlstKeylogger = FileReader.ReadFile(keyloggerFileInfo.FullName);
            var KeyLogger = ParseKeyLoggerFile(strlstKeylogger);
            //ReadMotionFile
            var strlstMotion = FileReader.ReadFile(motionFileInfo.FullName);
            var MotionData = ParseMotionFile(strlstMotion);
            //
            var trialSequence = new TrialSequence();
            trialSequence.LoadMetaData(MetaData);
            trialSequence.LoadKeyLoggerData(KeyLogger);
            trialSequence.LoadMotionData(MotionData);
            //
            Trials.AddRange(trialSequence.GetTrials(AddExtraMD));
            //
            if (Program._USEHARDCODE)
            {
                TrialSequences.Add(trialSequence);
            }
            //
            else
            //Send data to DB
            {
                DBC.MarkFolderAsScanned(Folder);
                DBC.SaveTrialSequence(trialSequence);
                foreach(var trial in Trials)
                {
                    DBC.SaveTrial(trial);
                }
            }
                
        }
        public void ScanSavedDataFolder(string PathToFolder, bool NewScan = true)
        {
            if (NewScan)
            {
                if(!Program._USEHARDCODE)
                    DBC.ClearAll();
                else
                {
                    Trials.Clear();
                    TrialSequences.Clear();
                }
            }
            FI.LoadScannedSubFolders(DBC.GetScannedFolders());
            var Folders = FileReader.EnumerateSubFolders(PathToFolder);
            foreach(var Folder in Folders)
            {
                switch (FI.ScanSubFolder(Folder))
                {
                    case FolderIndexer.ScanResult.Scanned:
                        {
                            break;
                        }
                    case FolderIndexer.ScanResult.NotScanned:
                        {
                            ProcessNewSubFolder(Folder);
                            break;
                        }
                }

            }
        }
    }
}
