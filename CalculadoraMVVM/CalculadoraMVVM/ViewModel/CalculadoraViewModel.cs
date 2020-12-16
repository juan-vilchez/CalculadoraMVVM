using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalculadoraMVVM.ViewModel
{
    class CalculadoraViewModel : ViewModelBase
    {


        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;



        #region Propiedades
        String result;
        public String Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Comandos 
        public ICommand Sumar { protected set; get; }

        public ICommand OnSelectNumberOne { protected set; get; }
        public ICommand OnSelectNumberTwo { protected set; get; }
        public ICommand OnSelectNumberThree { protected set; get; }
        public ICommand OnSelectNumberFour { protected set; get; }
        public ICommand OnSelectNumberFive { protected set; get; }
        public ICommand OnSelectNumberSix { protected set; get; }
        public ICommand OnSelectNumberSeven { protected set; get; }
        public ICommand OnSelectNumberEight { protected set; get; }
        public ICommand OnSelectNumberNine { protected set; get; }
        public ICommand OnSelectNumberZero { protected set; get; }
        public ICommand OnSelectClear { protected set; get; }
        public ICommand OnSelectDiv { protected set; get; }
        public ICommand OnSelectMul { protected set; get; }
        public ICommand OnSelectSum { protected set; get; }
        public ICommand OnSelectRes { protected set; get; }
        public ICommand OnSelectRespuesta { protected set; get; }
        #endregion

        #region Constructor

        public CalculadoraViewModel()
        {

            OnSelectNumberZero = new Command(() =>{
                OnSelectNumber("0");
            });
            OnSelectNumberOne = new Command(() =>
            {
                OnSelectNumber("1");
            });
            OnSelectNumberTwo = new Command(() =>
            {
                OnSelectNumber("2");
            });
            OnSelectNumberThree = new Command(() => {
                OnSelectNumber("3");
            });
            OnSelectNumberFour = new Command(() => {
                OnSelectNumber("4");
            });
            OnSelectNumberFive = new Command(() => {
                OnSelectNumber("5");
            });
            OnSelectNumberSix = new Command(() => {
                OnSelectNumber("6");
            });
            OnSelectNumberSeven = new Command(() => {
                OnSelectNumber("7");
            });
            OnSelectNumberEight = new Command(() => {
                OnSelectNumber("8");
            });
            OnSelectNumberNine = new Command(() => {
                OnSelectNumber("9");
            });
            //limpiar
            OnSelectClear = new Command(() => {
                OnClear("C");
            });
            //Dividir
            OnSelectDiv = new Command(() => {
                OnSelectOperator("÷");
            });
            //Multiplicar
            OnSelectMul = new Command(() => {
                OnSelectOperator("x");
            });
            //Dividir
            OnSelectSum = new Command(() => {
                OnSelectOperator("+");
            });
            //Dividir
            OnSelectRes = new Command(() => {
                OnSelectOperator("-");
            });
            //Respuesta =
            OnSelectRespuesta = new Command(() => {
                OnCalculate("=");
            });


        }
        #endregion

       

        void OnSelectOperator(String pressed)
        {
            currentState = -2;
            mathOperator = pressed;
        }


        void OnClear(String pressed)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            Result = "0";
        }


        void OnSelectNumber(String pressed)
        {
            Console.WriteLine("sjdoaijsdsel");

            if (Result == "0" || currentState < 0)
            {
                Result = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            Result += pressed;

            double number;
            if (double.TryParse(Result, out number))
            {
                Result = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }
        void OnCalculate(String pressed)
        {
            Console.WriteLine("sjdoaijsdppp");
            if (currentState == 2)
            {

                double result = 0;


                if (mathOperator == "+")
                {
                    result = firstNumber + secondNumber;
                    Result = result + "";
                    currentState = -1;
                }
                else if (mathOperator == "-") {
                    result = firstNumber - secondNumber;
                    Result = result + "";
                    currentState = -1;
                }
                else if (mathOperator == "x")
                {
                    result = firstNumber * secondNumber;
                    Result = result + "";
                    currentState = -1;
                }
                else if (mathOperator == "÷")
                {
                    result = firstNumber / secondNumber;
                    Result = result + "";
                    currentState = -1;
                }

            }
        }
    }
}
