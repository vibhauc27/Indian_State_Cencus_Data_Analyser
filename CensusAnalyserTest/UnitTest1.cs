using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{  
    class CensusAnalyserTest
    {
        //static readonly string IndianStateCensusDataFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        //static readonly string IndianStateCensusDataWrongFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        //static readonly string IndianStateCensusDataWrongExtensionFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";
        //static readonly string DelimiterIndianStateCensusDataFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        //static readonly string WrongHeaderIndianStateCensusDataFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongHeaderIndiaStateCensusData.csv";
        //static readonly string IndianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";

        static readonly string IndianStateCodeFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static readonly string IndianStateCodeWrongFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static readonly string IndianStateCodeWrongExtensionFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianStateCode.txt";
        static readonly string DelimiterIndianStateCodeFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimeterIndiaStateCode.csv";
        static readonly string WrongHeaderIndianStateCodeFilePath = @"C:\Users\Vibha\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongHeaderIndiaStateCode.csv";
        static readonly string IndianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeFilePath, IndianStateCodeHeaders);
            Assert.AreEqual(36, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeWrongFilePath, IndianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, IndianStateCodeWrongExtensionFilePath, IndianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, DelimiterIndianStateCodeFilePath, IndianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, WrongHeaderIndianStateCodeFilePath, IndianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}