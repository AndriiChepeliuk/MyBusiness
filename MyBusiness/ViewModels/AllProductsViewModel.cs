﻿using MyBusiness.Data;
using System.Drawing;
using System.IO;

namespace MyBusiness.ViewModels
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ApplicationContext _context;
        
        public byte[] imG;

        public AllProductsViewModel()
        {
            _context = new ApplicationContext();
            
            imG = ReadFile(@"../../../Images/AllProducts.jpg");
        }

        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
