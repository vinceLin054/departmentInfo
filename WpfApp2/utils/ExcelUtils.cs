using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using WpfApp2.domain;
using WpfApp2.service;

namespace WpfApp2.utils
{
    class ExcelUtils
    {
        public static void export(String path,List<Member> members)
        {
            HSSFWorkbook wk = new HSSFWorkbook();
            ISheet isheet = wk.CreateSheet("Sheet1");
            isheet.SetColumnWidth(3, 20 * 256);
            IRow row;
            ICell cell;
            int rowIndex = 1;
            row= isheet.CreateRow(0);
            cell = row.CreateCell(0);
            cell.SetCellValue("姓名");
            cell = row.CreateCell(1);
            cell.SetCellValue("性别");
            cell = row.CreateCell(2);
            cell.SetCellValue("职位");
            cell = row.CreateCell(3);
            cell.SetCellValue("联系电话");
            for (rowIndex = 0; rowIndex < members.Count; rowIndex++)
            {
                row = isheet.CreateRow(rowIndex+1);
                cell = row.CreateCell(0);
                cell.SetCellValue(members[rowIndex].Name);
                cell = row.CreateCell(1);
                cell.SetCellValue(members[rowIndex].Sex);
                cell = row.CreateCell(2);
                cell.SetCellValue(members[rowIndex].Position);
                cell = row.CreateCell(3);
                cell.SetCellValue(members[rowIndex].Phone);
            }
            FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate);
            wk.Write(fs2); 
            wk.Close();
            fs2.Close();
            fs2.Dispose();
            MessageBox.Show("导出成功");
        }


        public static void downModel(String path)
        {
            HSSFWorkbook wk = new HSSFWorkbook();
            ISheet isheet = wk.CreateSheet("Sheet1");
            isheet.SetColumnWidth(3, 20 * 256);
            IRow row;
            ICell cell;
            row = isheet.CreateRow(0);
            cell = row.CreateCell(0);
            cell.SetCellValue("姓名");
            cell = row.CreateCell(1);
            cell.SetCellValue("性别");
            cell = row.CreateCell(2);
            cell.SetCellValue("职位");
            cell = row.CreateCell(3);
            cell.SetCellValue("联系电话");
            row = isheet.CreateRow(1);
            cell = row.CreateCell(0);
            cell.SetCellValue("张三");
            cell = row.CreateCell(1);
            cell.SetCellValue("男");
            cell = row.CreateCell(2);
            cell.SetCellValue("干事");
            cell = row.CreateCell(3);
            cell.SetCellValue("13159118112");
            FileStream fs2 = new FileStream(path, FileMode.OpenOrCreate);
            wk.Write(fs2);
            wk.Close();
            fs2.Close();
            fs2.Dispose();
            MessageBox.Show("下载成功");
        }
        public static void import(String path,int departmentId)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MemberService memberService = new MemberService();
                IWorkbook workbook = null;
                if (Path.GetExtension(fs.Name) == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else if (Path.GetExtension(fs.Name) == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                IRow row;
                memberService.deleteAllByDepemtId(departmentId);
                for (int i = 1; i < sheet.LastRowNum; i++) 
                {
                    row = sheet.GetRow(i); 
                    if (row != null)
                    {
                        string name = row.GetCell(0).ToString();
                        string sex = row.GetCell(1).ToString();
                        string position = row.GetCell(2).ToString();
                        string phone = row.GetCell(3).ToString();
                        memberService.add(name, sex, position, phone, departmentId);
                    }
                }
            }//using
            MessageBox.Show("导入成功");
        }
    }
}
