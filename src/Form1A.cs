using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using LinearAlgebra = MathNet.Numerics.LinearAlgebra;

namespace PolyGene
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        #region DLL_IMPORT

        public static OperationSystem OS;

        private IntPtr LoadDreDll()
        {
            if (!File.Exists(cdir + "dre.dll") &&
                !File.Exists(cdir + "dre.so") &&
                !File.Exists(cdir + "dre.dylib"))
                MessageBox.Show("Error: Cannot find dynamic lib, in current directory '" + cdir + "'.");

            switch (OS)
            {
                case OperationSystem.Windows: return LoadLibrary(cdir + "dre.dll");
                case OperationSystem.Linux: return dlopen_linux(cdir + "dre.so", 2);
                case OperationSystem.MacOSX: return dlopen_mac(cdir + "dre.dylib", 2);
            }
            return IntPtr.Zero;
        }

        private IntPtr GetFuncAddr(IntPtr lib, string func)
        {
            switch (OS)
            {
                case OperationSystem.Windows: return GetProcAddress(lib, func);
                case OperationSystem.Linux: return dlsym_linux(lib, func);
                case OperationSystem.MacOSX: return dlsym_mac(lib, func);
            }
            return IntPtr.Zero;
        }

        private void LoadLibrary()
        {
            IntPtr dre = LoadDreDll();
            GetHash = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GetHash"), typeof(DGetHash)) as DGetHash;
            MatchAllele = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "MatchAllele"), typeof(DMatchAllele)) as DMatchAllele;
            GFZ10_iiiiiiiiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiiiii"), typeof(DGFZ10_iiiiiiiiii)) as DGFZ10_iiiiiiiiii;
            GFZ10_iiiiiiiiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiiiij"), typeof(DGFZ10_iiiiiiiiij)) as DGFZ10_iiiiiiiiij;
            GFZ10_iiiiiiiijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiiijj"), typeof(DGFZ10_iiiiiiiijj)) as DGFZ10_iiiiiiiijj;
            GFZ10_iiiiiiiijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiiijk"), typeof(DGFZ10_iiiiiiiijk)) as DGFZ10_iiiiiiiijk;
            GFZ10_iiiiiiijjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiijjj"), typeof(DGFZ10_iiiiiiijjj)) as DGFZ10_iiiiiiijjj;
            GFZ10_iiiiiiijjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiijjk"), typeof(DGFZ10_iiiiiiijjk)) as DGFZ10_iiiiiiijjk;
            GFZ10_iiiiiiijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiiijkl"), typeof(DGFZ10_iiiiiiijkl)) as DGFZ10_iiiiiiijkl;
            GFZ10_iiiiiijjjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiijjjj"), typeof(DGFZ10_iiiiiijjjj)) as DGFZ10_iiiiiijjjj;
            GFZ10_iiiiiijjjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiijjjk"), typeof(DGFZ10_iiiiiijjjk)) as DGFZ10_iiiiiijjjk;
            GFZ10_iiiiiijjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiijjkk"), typeof(DGFZ10_iiiiiijjkk)) as DGFZ10_iiiiiijjkk;
            GFZ10_iiiiiijjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiijjkl"), typeof(DGFZ10_iiiiiijjkl)) as DGFZ10_iiiiiijjkl;
            GFZ10_iiiiiijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiiijklm"), typeof(DGFZ10_iiiiiijklm)) as DGFZ10_iiiiiijklm;
            GFZ10_iiiiijjjjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjjjj"), typeof(DGFZ10_iiiiijjjjj)) as DGFZ10_iiiiijjjjj;
            GFZ10_iiiiijjjjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjjjk"), typeof(DGFZ10_iiiiijjjjk)) as DGFZ10_iiiiijjjjk;
            GFZ10_iiiiijjjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjjkk"), typeof(DGFZ10_iiiiijjjkk)) as DGFZ10_iiiiijjjkk;
            GFZ10_iiiiijjjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjjkl"), typeof(DGFZ10_iiiiijjjkl)) as DGFZ10_iiiiijjjkl;
            GFZ10_iiiiijjkkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjkkl"), typeof(DGFZ10_iiiiijjkkl)) as DGFZ10_iiiiijjkkl;
            GFZ10_iiiiijjklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijjklm"), typeof(DGFZ10_iiiiijjklm)) as DGFZ10_iiiiijjklm;
            GFZ10_iiiiijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiiijklmn"), typeof(DGFZ10_iiiiijklmn)) as DGFZ10_iiiiijklmn;
            GFZ10_iiiijjjjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjjjkk"), typeof(DGFZ10_iiiijjjjkk)) as DGFZ10_iiiijjjjkk;
            GFZ10_iiiijjjjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjjjkl"), typeof(DGFZ10_iiiijjjjkl)) as DGFZ10_iiiijjjjkl;
            GFZ10_iiiijjjkkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjjkkk"), typeof(DGFZ10_iiiijjjkkk)) as DGFZ10_iiiijjjkkk;
            GFZ10_iiiijjjkkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjjkkl"), typeof(DGFZ10_iiiijjjkkl)) as DGFZ10_iiiijjjkkl;
            GFZ10_iiiijjjklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjjklm"), typeof(DGFZ10_iiiijjjklm)) as DGFZ10_iiiijjjklm;
            GFZ10_iiiijjkkll = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjkkll"), typeof(DGFZ10_iiiijjkkll)) as DGFZ10_iiiijjkkll;
            GFZ10_iiiijjkklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjkklm"), typeof(DGFZ10_iiiijjkklm)) as DGFZ10_iiiijjkklm;
            GFZ10_iiiijjklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijjklmn"), typeof(DGFZ10_iiiijjklmn)) as DGFZ10_iiiijjklmn;
            GFZ10_iiiijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiiijklmno"), typeof(DGFZ10_iiiijklmno)) as DGFZ10_iiiijklmno;
            GFZ10_iiijjjkkkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjjkkkl"), typeof(DGFZ10_iiijjjkkkl)) as DGFZ10_iiijjjkkkl;
            GFZ10_iiijjjkkll = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjjkkll"), typeof(DGFZ10_iiijjjkkll)) as DGFZ10_iiijjjkkll;
            GFZ10_iiijjjkklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjjkklm"), typeof(DGFZ10_iiijjjkklm)) as DGFZ10_iiijjjkklm;
            GFZ10_iiijjjklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjjklmn"), typeof(DGFZ10_iiijjjklmn)) as DGFZ10_iiijjjklmn;
            GFZ10_iiijjkkllm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjkkllm"), typeof(DGFZ10_iiijjkkllm)) as DGFZ10_iiijjkkllm;
            GFZ10_iiijjkklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjkklmn"), typeof(DGFZ10_iiijjkklmn)) as DGFZ10_iiijjkklmn;
            GFZ10_iiijjklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijjklmno"), typeof(DGFZ10_iiijjklmno)) as DGFZ10_iiijjklmno;
            GFZ10_iiijklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iiijklmnop"), typeof(DGFZ10_iiijklmnop)) as DGFZ10_iiijklmnop;
            GFZ10_iijjkkllmm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iijjkkllmm"), typeof(DGFZ10_iijjkkllmm)) as DGFZ10_iijjkkllmm;
            GFZ10_iijjkkllmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iijjkkllmn"), typeof(DGFZ10_iijjkkllmn)) as DGFZ10_iijjkkllmn;
            GFZ10_iijjkklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iijjkklmno"), typeof(DGFZ10_iijjkklmno)) as DGFZ10_iijjkklmno;
            GFZ10_iijjklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iijjklmnop"), typeof(DGFZ10_iijjklmnop)) as DGFZ10_iijjklmnop;
            GFZ10_iijklmnopq = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_iijklmnopq"), typeof(DGFZ10_iijklmnopq)) as DGFZ10_iijklmnopq;
            GFZ10_ijklmnopqr = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ10_ijklmnopqr"), typeof(DGFZ10_ijklmnopqr)) as DGFZ10_ijklmnopqr;
            PFZ10_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_i"), typeof(DPFZ10_i)) as DPFZ10_i;
            PFZ10_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ij"), typeof(DPFZ10_ij)) as DPFZ10_ij;
            PFZ10_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijk"), typeof(DPFZ10_ijk)) as DPFZ10_ijk;
            PFZ10_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijkl"), typeof(DPFZ10_ijkl)) as DPFZ10_ijkl;
            PFZ10_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklm"), typeof(DPFZ10_ijklm)) as DPFZ10_ijklm;
            PFZ10_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklmn"), typeof(DPFZ10_ijklmn)) as DPFZ10_ijklmn;
            PFZ10_ijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklmno"), typeof(DPFZ10_ijklmno)) as DPFZ10_ijklmno;
            PFZ10_ijklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklmnop"), typeof(DPFZ10_ijklmnop)) as DPFZ10_ijklmnop;
            PFZ10_ijklmnopq = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklmnopq"), typeof(DPFZ10_ijklmnopq)) as DPFZ10_ijklmnopq;
            PFZ10_ijklmnopqr = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ10_ijklmnopqr"), typeof(DPFZ10_ijklmnopqr)) as DPFZ10_ijklmnopqr;
            GFG10_iiiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iiiii"), typeof(DGFG10_iiiii)) as DGFG10_iiiii;
            GFG10_iiiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iiiij"), typeof(DGFG10_iiiij)) as DGFG10_iiiij;
            GFG10_iiijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iiijj"), typeof(DGFG10_iiijj)) as DGFG10_iiijj;
            GFG10_iiijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iiijk"), typeof(DGFG10_iiijk)) as DGFG10_iiijk;
            GFG10_iijjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iijjk"), typeof(DGFG10_iijjk)) as DGFG10_iijjk;
            GFG10_iijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_iijkl"), typeof(DGFG10_iijkl)) as DGFG10_iijkl;
            GFG10_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG10_ijklm"), typeof(DGFG10_ijklm)) as DGFG10_ijklm;
            PFG10_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG10_i"), typeof(DPFG10_i)) as DPFG10_i;
            PFG10_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG10_ij"), typeof(DPFG10_ij)) as DPFG10_ij;
            PFG10_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG10_ijk"), typeof(DPFG10_ijk)) as DPFG10_ijk;
            PFG10_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG10_ijkl"), typeof(DPFG10_ijkl)) as DPFG10_ijkl;
            PFG10_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG10_ijklm"), typeof(DPFG10_ijklm)) as DPFG10_ijklm;
            GFZ8_iiiiiiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiiiii"), typeof(DGFZ8_iiiiiiii)) as DGFZ8_iiiiiiii;
            GFZ8_iiiiiiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiiiij"), typeof(DGFZ8_iiiiiiij)) as DGFZ8_iiiiiiij;
            GFZ8_iiiiiijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiiijj"), typeof(DGFZ8_iiiiiijj)) as DGFZ8_iiiiiijj;
            GFZ8_iiiiiijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiiijk"), typeof(DGFZ8_iiiiiijk)) as DGFZ8_iiiiiijk;
            GFZ8_iiiiijjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiijjj"), typeof(DGFZ8_iiiiijjj)) as DGFZ8_iiiiijjj;
            GFZ8_iiiiijjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiijjk"), typeof(DGFZ8_iiiiijjk)) as DGFZ8_iiiiijjk;
            GFZ8_iiiiijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiiijkl"), typeof(DGFZ8_iiiiijkl)) as DGFZ8_iiiiijkl;
            GFZ8_iiiijjjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiijjjj"), typeof(DGFZ8_iiiijjjj)) as DGFZ8_iiiijjjj;
            GFZ8_iiiijjjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiijjjk"), typeof(DGFZ8_iiiijjjk)) as DGFZ8_iiiijjjk;
            GFZ8_iiiijjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiijjkk"), typeof(DGFZ8_iiiijjkk)) as DGFZ8_iiiijjkk;
            GFZ8_iiiijjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiijjkl"), typeof(DGFZ8_iiiijjkl)) as DGFZ8_iiiijjkl;
            GFZ8_iiiijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiiijklm"), typeof(DGFZ8_iiiijklm)) as DGFZ8_iiiijklm;
            GFZ8_iiijjjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiijjjkk"), typeof(DGFZ8_iiijjjkk)) as DGFZ8_iiijjjkk;
            GFZ8_iiijjjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiijjjkl"), typeof(DGFZ8_iiijjjkl)) as DGFZ8_iiijjjkl;
            GFZ8_iiijjkkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiijjkkl"), typeof(DGFZ8_iiijjkkl)) as DGFZ8_iiijjkkl;
            GFZ8_iiijjklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiijjklm"), typeof(DGFZ8_iiijjklm)) as DGFZ8_iiijjklm;
            GFZ8_iiijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iiijklmn"), typeof(DGFZ8_iiijklmn)) as DGFZ8_iiijklmn;
            GFZ8_iijjkkll = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iijjkkll"), typeof(DGFZ8_iijjkkll)) as DGFZ8_iijjkkll;
            GFZ8_iijjkklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iijjkklm"), typeof(DGFZ8_iijjkklm)) as DGFZ8_iijjkklm;
            GFZ8_iijjklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iijjklmn"), typeof(DGFZ8_iijjklmn)) as DGFZ8_iijjklmn;
            GFZ8_iijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_iijklmno"), typeof(DGFZ8_iijklmno)) as DGFZ8_iijklmno;
            GFZ8_ijklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ8_ijklmnop"), typeof(DGFZ8_ijklmnop)) as DGFZ8_ijklmnop;
            PFZ8_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_i"), typeof(DPFZ8_i)) as DPFZ8_i;
            PFZ8_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ij"), typeof(DPFZ8_ij)) as DPFZ8_ij;
            PFZ8_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijk"), typeof(DPFZ8_ijk)) as DPFZ8_ijk;
            PFZ8_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijkl"), typeof(DPFZ8_ijkl)) as DPFZ8_ijkl;
            PFZ8_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijklm"), typeof(DPFZ8_ijklm)) as DPFZ8_ijklm;
            PFZ8_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijklmn"), typeof(DPFZ8_ijklmn)) as DPFZ8_ijklmn;
            PFZ8_ijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijklmno"), typeof(DPFZ8_ijklmno)) as DPFZ8_ijklmno;
            PFZ8_ijklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ8_ijklmnop"), typeof(DPFZ8_ijklmnop)) as DPFZ8_ijklmnop;
            GFG8_iiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG8_iiii"), typeof(DGFG8_iiii)) as DGFG8_iiii;
            GFG8_iiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG8_iiij"), typeof(DGFG8_iiij)) as DGFG8_iiij;
            GFG8_iijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG8_iijj"), typeof(DGFG8_iijj)) as DGFG8_iijj;
            GFG8_iijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG8_iijk"), typeof(DGFG8_iijk)) as DGFG8_iijk;
            GFG8_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG8_ijkl"), typeof(DGFG8_ijkl)) as DGFG8_ijkl;
            PFG8_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG8_i"), typeof(DPFG8_i)) as DPFG8_i;
            PFG8_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG8_ij"), typeof(DPFG8_ij)) as DPFG8_ij;
            PFG8_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG8_ijk"), typeof(DPFG8_ijk)) as DPFG8_ijk;
            PFG8_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG8_ijkl"), typeof(DPFG8_ijkl)) as DPFG8_ijkl;
            GFZ6_iiiiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiiiii"), typeof(DGFZ6_iiiiii)) as DGFZ6_iiiiii;
            GFZ6_iiiiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiiiij"), typeof(DGFZ6_iiiiij)) as DGFZ6_iiiiij;
            GFZ6_iiiijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiiijj"), typeof(DGFZ6_iiiijj)) as DGFZ6_iiiijj;
            GFZ6_iiiijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiiijk"), typeof(DGFZ6_iiiijk)) as DGFZ6_iiiijk;
            GFZ6_iiijjj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiijjj"), typeof(DGFZ6_iiijjj)) as DGFZ6_iiijjj;
            GFZ6_iiijjk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiijjk"), typeof(DGFZ6_iiijjk)) as DGFZ6_iiijjk;
            GFZ6_iiijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iiijkl"), typeof(DGFZ6_iiijkl)) as DGFZ6_iiijkl;
            GFZ6_iijjkk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iijjkk"), typeof(DGFZ6_iijjkk)) as DGFZ6_iijjkk;
            GFZ6_iijjkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iijjkl"), typeof(DGFZ6_iijjkl)) as DGFZ6_iijjkl;
            GFZ6_iijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_iijklm"), typeof(DGFZ6_iijklm)) as DGFZ6_iijklm;
            GFZ6_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ6_ijklmn"), typeof(DGFZ6_ijklmn)) as DGFZ6_ijklmn;
            PFZ6_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_i"), typeof(DPFZ6_i)) as DPFZ6_i;
            PFZ6_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_ij"), typeof(DPFZ6_ij)) as DPFZ6_ij;
            PFZ6_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_ijk"), typeof(DPFZ6_ijk)) as DPFZ6_ijk;
            PFZ6_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_ijkl"), typeof(DPFZ6_ijkl)) as DPFZ6_ijkl;
            PFZ6_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_ijklm"), typeof(DPFZ6_ijklm)) as DPFZ6_ijklm;
            PFZ6_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ6_ijklmn"), typeof(DPFZ6_ijklmn)) as DPFZ6_ijklmn;
            GFG6_iii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG6_iii"), typeof(DGFG6_iii)) as DGFG6_iii;
            GFG6_iij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG6_iij"), typeof(DGFG6_iij)) as DGFG6_iij;
            GFG6_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG6_ijk"), typeof(DGFG6_ijk)) as DGFG6_ijk;
            PFG6_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG6_i"), typeof(DPFG6_i)) as DPFG6_i;
            PFG6_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG6_ij"), typeof(DPFG6_ij)) as DPFG6_ij;
            PFG6_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG6_ijk"), typeof(DPFG6_ijk)) as DPFG6_ijk;
            GFZ4_iiii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ4_iiii"), typeof(DGFZ4_iiii)) as DGFZ4_iiii;
            GFZ4_iiij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ4_iiij"), typeof(DGFZ4_iiij)) as DGFZ4_iiij;
            GFZ4_iijj = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ4_iijj"), typeof(DGFZ4_iijj)) as DGFZ4_iijj;
            GFZ4_iijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ4_iijk"), typeof(DGFZ4_iijk)) as DGFZ4_iijk;
            GFZ4_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFZ4_ijkl"), typeof(DGFZ4_ijkl)) as DGFZ4_ijkl;
            PFZ4_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ4_i"), typeof(DPFZ4_i)) as DPFZ4_i;
            PFZ4_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ4_ij"), typeof(DPFZ4_ij)) as DPFZ4_ij;
            PFZ4_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ4_ijk"), typeof(DPFZ4_ijk)) as DPFZ4_ijk;
            PFZ4_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ4_ijkl"), typeof(DPFZ4_ijkl)) as DPFZ4_ijkl;
            GFG4_ii = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG4_ii"), typeof(DGFG4_ii)) as DGFG4_ii;
            GFG4_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "GFG4_ij"), typeof(DGFG4_ij)) as DGFG4_ij;
            PFG4_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG4_i"), typeof(DPFG4_i)) as DPFG4_i;
            PFG4_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFG4_ij"), typeof(DPFG4_ij)) as DPFG4_ij;
            PFZ3_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ3_i"), typeof(DPFZ3_i)) as DPFZ3_i;
            PFZ3_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ3_ij"), typeof(DPFZ3_ij)) as DPFZ3_ij;
            PFZ3_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ3_ijk"), typeof(DPFZ3_ijk)) as DPFZ3_ijk;
            PFZ5_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ5_i"), typeof(DPFZ5_i)) as DPFZ5_i;
            PFZ5_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ5_ij"), typeof(DPFZ5_ij)) as DPFZ5_ij;
            PFZ5_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ5_ijk"), typeof(DPFZ5_ijk)) as DPFZ5_ijk;
            PFZ5_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ5_ijkl"), typeof(DPFZ5_ijkl)) as DPFZ5_ijkl;
            PFZ5_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ5_ijklm"), typeof(DPFZ5_ijklm)) as DPFZ5_ijklm;
            PFZ7_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_i"), typeof(DPFZ7_i)) as DPFZ7_i;
            PFZ7_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ij"), typeof(DPFZ7_ij)) as DPFZ7_ij;
            PFZ7_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ijk"), typeof(DPFZ7_ijk)) as DPFZ7_ijk;
            PFZ7_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ijkl"), typeof(DPFZ7_ijkl)) as DPFZ7_ijkl;
            PFZ7_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ijklm"), typeof(DPFZ7_ijklm)) as DPFZ7_ijklm;
            PFZ7_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ijklmn"), typeof(DPFZ7_ijklmn)) as DPFZ7_ijklmn;
            PFZ7_ijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ7_ijklmno"), typeof(DPFZ7_ijklmno)) as DPFZ7_ijklmno;
            PFZ9_i = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_i"), typeof(DPFZ9_i)) as DPFZ9_i;
            PFZ9_ij = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ij"), typeof(DPFZ9_ij)) as DPFZ9_ij;
            PFZ9_ijk = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijk"), typeof(DPFZ9_ijk)) as DPFZ9_ijk;
            PFZ9_ijkl = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijkl"), typeof(DPFZ9_ijkl)) as DPFZ9_ijkl;
            PFZ9_ijklm = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijklm"), typeof(DPFZ9_ijklm)) as DPFZ9_ijklm;
            PFZ9_ijklmn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijklmn"), typeof(DPFZ9_ijklmn)) as DPFZ9_ijklmn;
            PFZ9_ijklmno = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijklmno"), typeof(DPFZ9_ijklmno)) as DPFZ9_ijklmno;
            PFZ9_ijklmnop = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijklmnop"), typeof(DPFZ9_ijklmnop)) as DPFZ9_ijklmnop;
            PFZ9_ijklmnopq = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "PFZ9_ijklmnopq"), typeof(DPFZ9_ijklmnopq)) as DPFZ9_ijklmnopq;
            Thomas2000LikelihoodIn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "Thomas2000LikelihoodIn"), typeof(DThomas2000LikelihoodIn)) as DThomas2000LikelihoodIn;
            Mousseau1998LikelihoodIn = Marshal.GetDelegateForFunctionPointer(GetFuncAddr(dre, "Mousseau1998LikelihoodIn"), typeof(DMousseau1998LikelihoodIn)) as DMousseau1998LikelihoodIn;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder text, int len);

        [DllImport("libdl.so", EntryPoint = "dlopen")]
        protected static extern IntPtr dlopen_linux(string filename, int flags);

        [DllImport("libdl.so", EntryPoint = "dlsym")]
        protected static extern IntPtr dlsym_linux(IntPtr handle, string symbol);

        [DllImport("libdl.dylib", EntryPoint = "dlopen")]
        protected static extern IntPtr dlopen_mac(string filename, int flags);

        [DllImport("libdl.dylib", EntryPoint = "dlsym")]
        protected static extern IntPtr dlsym_mac(IntPtr handle, string symbol);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);


        public delegate uint DGetHash(int[] x, int[] y, int maxploidy);
        public delegate uint DMatchAllele(ulong code, int[] bufa, int[] bufb, int[,,] alleles, int offset, int ploidy);
        public delegate double DThomas2000LikelihoodIn(double h2, double vp, double[] vx2, double[,] prfs, double f, int n, int v);
        public delegate double DMousseau1998LikelihoodIn(double h2, double[] vx2, double[] prfs, double f, int n, int v);
        public delegate double DGFZ10_iiiiiiiiii(double a1, double a2, double pi);
        public delegate double DGFZ10_iiiiiiiiij(double a1, double a2, double pi, double pj);
        public delegate double DGFZ10_iiiiiiiijj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ10_iiiiiiiijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiiiijjj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ10_iiiiiiijjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiiiijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiiiijjjj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ10_iiiiiijjjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiiijjkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiiijjkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiiiijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiiiijjjjj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ10_iiiiijjjjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiijjjkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiiijjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiiijjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiiijjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiiiijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ10_iiiijjjjkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiijjjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiijjjkkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ10_iiiijjjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiijjjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiiijjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiiijjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiiijjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ10_iiiijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DGFZ10_iiijjjkkkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiijjjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ10_iiijjjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiijjjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ10_iiijjkkllm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iiijjkklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ10_iiijjklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DGFZ10_iiijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DGFZ10_iijjkkllmm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ10_iijjkkllmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ10_iijjkklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DGFZ10_iijjklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DGFZ10_iijklmnopq(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);
        public delegate double DGFZ10_ijklmnopqr(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq, double pr);
        public delegate double DPFZ10_i(double a1, double a2, double pi);
        public delegate double DPFZ10_ij(double a1, double a2, double pi, double pj);
        public delegate double DPFZ10_ijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DPFZ10_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DPFZ10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ10_ijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DPFZ10_ijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DPFZ10_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DPFZ10_ijklmnopq(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);
        public delegate double DPFZ10_ijklmnopqr(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq, double pr);
        public delegate double DGFG10_iiiii(double a1, double a2, double pi);
        public delegate double DGFG10_iiiij(double a1, double a2, double pi, double pj);
        public delegate double DGFG10_iiijj(double a1, double a2, double pi, double pj);
        public delegate double DGFG10_iiijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFG10_iijjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFG10_iijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFG10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFG10_i(double a1, double a2, double pi);
        public delegate double DPFG10_ij(double a1, double a2, double pi, double pj);
        public delegate double DPFG10_ijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DPFG10_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DPFG10_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ8_iiiiiiii(double a1, double a2, double pi);
        public delegate double DGFZ8_iiiiiiij(double a1, double a2, double pi, double pj);
        public delegate double DGFZ8_iiiiiijj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ8_iiiiiijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ8_iiiiijjj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ8_iiiiijjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ8_iiiiijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ8_iiiijjjj(double a1, double a2, double pi, double pj);
        public delegate double DGFZ8_iiiijjjk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ8_iiiijjkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ8_iiiijjkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ8_iiiijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ8_iiijjjkk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFZ8_iiijjjkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ8_iiijjkkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ8_iiijjklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ8_iiijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ8_iijjkkll(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ8_iijjkklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ8_iijjklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFZ8_iijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DGFZ8_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DPFZ8_i(double a1, double a2, double pi);
        public delegate double DPFZ8_ij(double a1, double a2, double pi, double pj);
        public delegate double DPFZ8_ijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DPFZ8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DPFZ8_ijklm(double a1, double a2, double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ8_ijklmn(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DPFZ8_ijklmno(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DPFZ8_ijklmnop(double a1, double a2, double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DGFG8_iiii(double a1, double a2, double pi);
        public delegate double DGFG8_iiij(double a1, double a2, double pi, double pj);
        public delegate double DGFG8_iijj(double a1, double a2, double pi, double pj);
        public delegate double DGFG8_iijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DGFG8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DPFG8_i(double a1, double a2, double pi);
        public delegate double DPFG8_ij(double a1, double a2, double pi, double pj);
        public delegate double DPFG8_ijk(double a1, double a2, double pi, double pj, double pk);
        public delegate double DPFG8_ijkl(double a1, double a2, double pi, double pj, double pk, double pl);
        public delegate double DGFZ6_iiiiii(double a1, double pi);
        public delegate double DGFZ6_iiiiij(double a1, double pi, double pj);
        public delegate double DGFZ6_iiiijj(double a1, double pi, double pj);
        public delegate double DGFZ6_iiiijk(double a1, double pi, double pj, double pk);
        public delegate double DGFZ6_iiijjj(double a1, double pi, double pj);
        public delegate double DGFZ6_iiijjk(double a1, double pi, double pj, double pk);
        public delegate double DGFZ6_iiijkl(double a1, double pi, double pj, double pk, double pl);
        public delegate double DGFZ6_iijjkk(double a1, double pi, double pj, double pk);
        public delegate double DGFZ6_iijjkl(double a1, double pi, double pj, double pk, double pl);
        public delegate double DGFZ6_iijklm(double a1, double pi, double pj, double pk, double pl, double pm);
        public delegate double DGFZ6_ijklmn(double a1, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DPFZ6_i(double a1, double pi);
        public delegate double DPFZ6_ij(double a1, double pi, double pj);
        public delegate double DPFZ6_ijk(double a1, double pi, double pj, double pk);
        public delegate double DPFZ6_ijkl(double a1, double pi, double pj, double pk, double pl);
        public delegate double DPFZ6_ijklm(double a1, double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ6_ijklmn(double a1, double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DGFG6_iii(double a1, double pi);
        public delegate double DGFG6_iij(double a1, double pi, double pj);
        public delegate double DGFG6_ijk(double a1, double pi, double pj, double pk);
        public delegate double DPFG6_i(double a1, double pi);
        public delegate double DPFG6_ij(double a1, double pi, double pj);
        public delegate double DPFG6_ijk(double a1, double pi, double pj, double pk);
        public delegate double DGFZ4_iiii(double a1, double pi);
        public delegate double DGFZ4_iiij(double a1, double pi, double pj);
        public delegate double DGFZ4_iijj(double a1, double pi, double pj);
        public delegate double DGFZ4_iijk(double a1, double pi, double pj, double pk);
        public delegate double DGFZ4_ijkl(double a1, double pi, double pj, double pk, double pl);
        public delegate double DPFZ4_i(double a1, double pi);
        public delegate double DPFZ4_ij(double a1, double pi, double pj);
        public delegate double DPFZ4_ijk(double a1, double pi, double pj, double pk);
        public delegate double DPFZ4_ijkl(double a1, double pi, double pj, double pk, double pl);
        public delegate double DGFG4_ii(double a1, double pi);
        public delegate double DGFG4_ij(double a1, double pi, double pj);
        public delegate double DPFG4_i(double a1, double pi);
        public delegate double DPFG4_ij(double a1, double pi, double pj);
        public delegate double DPFZ3_i(double pi);
        public delegate double DPFZ3_ij(double pi, double pj);
        public delegate double DPFZ3_ijk(double pi, double pj, double pk);
        public delegate double DPFZ5_i(double pi);
        public delegate double DPFZ5_ij(double pi, double pj);
        public delegate double DPFZ5_ijk(double pi, double pj, double pk);
        public delegate double DPFZ5_ijkl(double pi, double pj, double pk, double pl);
        public delegate double DPFZ5_ijklm(double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ7_i(double pi);
        public delegate double DPFZ7_ij(double pi, double pj);
        public delegate double DPFZ7_ijk(double pi, double pj, double pk);
        public delegate double DPFZ7_ijkl(double pi, double pj, double pk, double pl);
        public delegate double DPFZ7_ijklm(double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ7_ijklmn(double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DPFZ7_ijklmno(double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DPFZ9_i(double pi);
        public delegate double DPFZ9_ij(double pi, double pj);
        public delegate double DPFZ9_ijk(double pi, double pj, double pk);
        public delegate double DPFZ9_ijkl(double pi, double pj, double pk, double pl);
        public delegate double DPFZ9_ijklm(double pi, double pj, double pk, double pl, double pm);
        public delegate double DPFZ9_ijklmn(double pi, double pj, double pk, double pl, double pm, double pn);
        public delegate double DPFZ9_ijklmno(double pi, double pj, double pk, double pl, double pm, double pn, double po);
        public delegate double DPFZ9_ijklmnop(double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp);
        public delegate double DPFZ9_ijklmnopq(double pi, double pj, double pk, double pl, double pm, double pn, double po, double pp, double pq);

        public static DGetHash GetHash;
        public static DMatchAllele MatchAllele;
        public static DThomas2000LikelihoodIn Thomas2000LikelihoodIn;
        public static DMousseau1998LikelihoodIn Mousseau1998LikelihoodIn;
        public static DGFZ10_iiiiiiiiii GFZ10_iiiiiiiiii;
        public static DGFZ10_iiiiiiiiij GFZ10_iiiiiiiiij;
        public static DGFZ10_iiiiiiiijj GFZ10_iiiiiiiijj;
        public static DGFZ10_iiiiiiiijk GFZ10_iiiiiiiijk;
        public static DGFZ10_iiiiiiijjj GFZ10_iiiiiiijjj;
        public static DGFZ10_iiiiiiijjk GFZ10_iiiiiiijjk;
        public static DGFZ10_iiiiiiijkl GFZ10_iiiiiiijkl;
        public static DGFZ10_iiiiiijjjj GFZ10_iiiiiijjjj;
        public static DGFZ10_iiiiiijjjk GFZ10_iiiiiijjjk;
        public static DGFZ10_iiiiiijjkk GFZ10_iiiiiijjkk;
        public static DGFZ10_iiiiiijjkl GFZ10_iiiiiijjkl;
        public static DGFZ10_iiiiiijklm GFZ10_iiiiiijklm;
        public static DGFZ10_iiiiijjjjj GFZ10_iiiiijjjjj;
        public static DGFZ10_iiiiijjjjk GFZ10_iiiiijjjjk;
        public static DGFZ10_iiiiijjjkk GFZ10_iiiiijjjkk;
        public static DGFZ10_iiiiijjjkl GFZ10_iiiiijjjkl;
        public static DGFZ10_iiiiijjkkl GFZ10_iiiiijjkkl;
        public static DGFZ10_iiiiijjklm GFZ10_iiiiijjklm;
        public static DGFZ10_iiiiijklmn GFZ10_iiiiijklmn;
        public static DGFZ10_iiiijjjjkk GFZ10_iiiijjjjkk;
        public static DGFZ10_iiiijjjjkl GFZ10_iiiijjjjkl;
        public static DGFZ10_iiiijjjkkk GFZ10_iiiijjjkkk;
        public static DGFZ10_iiiijjjkkl GFZ10_iiiijjjkkl;
        public static DGFZ10_iiiijjjklm GFZ10_iiiijjjklm;
        public static DGFZ10_iiiijjkkll GFZ10_iiiijjkkll;
        public static DGFZ10_iiiijjkklm GFZ10_iiiijjkklm;
        public static DGFZ10_iiiijjklmn GFZ10_iiiijjklmn;
        public static DGFZ10_iiiijklmno GFZ10_iiiijklmno;
        public static DGFZ10_iiijjjkkkl GFZ10_iiijjjkkkl;
        public static DGFZ10_iiijjjkkll GFZ10_iiijjjkkll;
        public static DGFZ10_iiijjjkklm GFZ10_iiijjjkklm;
        public static DGFZ10_iiijjjklmn GFZ10_iiijjjklmn;
        public static DGFZ10_iiijjkkllm GFZ10_iiijjkkllm;
        public static DGFZ10_iiijjkklmn GFZ10_iiijjkklmn;
        public static DGFZ10_iiijjklmno GFZ10_iiijjklmno;
        public static DGFZ10_iiijklmnop GFZ10_iiijklmnop;
        public static DGFZ10_iijjkkllmm GFZ10_iijjkkllmm;
        public static DGFZ10_iijjkkllmn GFZ10_iijjkkllmn;
        public static DGFZ10_iijjkklmno GFZ10_iijjkklmno;
        public static DGFZ10_iijjklmnop GFZ10_iijjklmnop;
        public static DGFZ10_iijklmnopq GFZ10_iijklmnopq;
        public static DGFZ10_ijklmnopqr GFZ10_ijklmnopqr;
        public static DPFZ10_i PFZ10_i;
        public static DPFZ10_ij PFZ10_ij;
        public static DPFZ10_ijk PFZ10_ijk;
        public static DPFZ10_ijkl PFZ10_ijkl;
        public static DPFZ10_ijklm PFZ10_ijklm;
        public static DPFZ10_ijklmn PFZ10_ijklmn;
        public static DPFZ10_ijklmno PFZ10_ijklmno;
        public static DPFZ10_ijklmnop PFZ10_ijklmnop;
        public static DPFZ10_ijklmnopq PFZ10_ijklmnopq;
        public static DPFZ10_ijklmnopqr PFZ10_ijklmnopqr;
        public static DGFG10_iiiii GFG10_iiiii;
        public static DGFG10_iiiij GFG10_iiiij;
        public static DGFG10_iiijj GFG10_iiijj;
        public static DGFG10_iiijk GFG10_iiijk;
        public static DGFG10_iijjk GFG10_iijjk;
        public static DGFG10_iijkl GFG10_iijkl;
        public static DGFG10_ijklm GFG10_ijklm;
        public static DPFG10_i PFG10_i;
        public static DPFG10_ij PFG10_ij;
        public static DPFG10_ijk PFG10_ijk;
        public static DPFG10_ijkl PFG10_ijkl;
        public static DPFG10_ijklm PFG10_ijklm;
        public static DGFZ8_iiiiiiii GFZ8_iiiiiiii;
        public static DGFZ8_iiiiiiij GFZ8_iiiiiiij;
        public static DGFZ8_iiiiiijj GFZ8_iiiiiijj;
        public static DGFZ8_iiiiiijk GFZ8_iiiiiijk;
        public static DGFZ8_iiiiijjj GFZ8_iiiiijjj;
        public static DGFZ8_iiiiijjk GFZ8_iiiiijjk;
        public static DGFZ8_iiiiijkl GFZ8_iiiiijkl;
        public static DGFZ8_iiiijjjj GFZ8_iiiijjjj;
        public static DGFZ8_iiiijjjk GFZ8_iiiijjjk;
        public static DGFZ8_iiiijjkk GFZ8_iiiijjkk;
        public static DGFZ8_iiiijjkl GFZ8_iiiijjkl;
        public static DGFZ8_iiiijklm GFZ8_iiiijklm;
        public static DGFZ8_iiijjjkk GFZ8_iiijjjkk;
        public static DGFZ8_iiijjjkl GFZ8_iiijjjkl;
        public static DGFZ8_iiijjkkl GFZ8_iiijjkkl;
        public static DGFZ8_iiijjklm GFZ8_iiijjklm;
        public static DGFZ8_iiijklmn GFZ8_iiijklmn;
        public static DGFZ8_iijjkkll GFZ8_iijjkkll;
        public static DGFZ8_iijjkklm GFZ8_iijjkklm;
        public static DGFZ8_iijjklmn GFZ8_iijjklmn;
        public static DGFZ8_iijklmno GFZ8_iijklmno;
        public static DGFZ8_ijklmnop GFZ8_ijklmnop;
        public static DPFZ8_i PFZ8_i;
        public static DPFZ8_ij PFZ8_ij;
        public static DPFZ8_ijk PFZ8_ijk;
        public static DPFZ8_ijkl PFZ8_ijkl;
        public static DPFZ8_ijklm PFZ8_ijklm;
        public static DPFZ8_ijklmn PFZ8_ijklmn;
        public static DPFZ8_ijklmno PFZ8_ijklmno;
        public static DPFZ8_ijklmnop PFZ8_ijklmnop;
        public static DGFG8_iiii GFG8_iiii;
        public static DGFG8_iiij GFG8_iiij;
        public static DGFG8_iijj GFG8_iijj;
        public static DGFG8_iijk GFG8_iijk;
        public static DGFG8_ijkl GFG8_ijkl;
        public static DPFG8_i PFG8_i;
        public static DPFG8_ij PFG8_ij;
        public static DPFG8_ijk PFG8_ijk;
        public static DPFG8_ijkl PFG8_ijkl;
        public static DGFZ6_iiiiii GFZ6_iiiiii;
        public static DGFZ6_iiiiij GFZ6_iiiiij;
        public static DGFZ6_iiiijj GFZ6_iiiijj;
        public static DGFZ6_iiiijk GFZ6_iiiijk;
        public static DGFZ6_iiijjj GFZ6_iiijjj;
        public static DGFZ6_iiijjk GFZ6_iiijjk;
        public static DGFZ6_iiijkl GFZ6_iiijkl;
        public static DGFZ6_iijjkk GFZ6_iijjkk;
        public static DGFZ6_iijjkl GFZ6_iijjkl;
        public static DGFZ6_iijklm GFZ6_iijklm;
        public static DGFZ6_ijklmn GFZ6_ijklmn;
        public static DPFZ6_i PFZ6_i;
        public static DPFZ6_ij PFZ6_ij;
        public static DPFZ6_ijk PFZ6_ijk;
        public static DPFZ6_ijkl PFZ6_ijkl;
        public static DPFZ6_ijklm PFZ6_ijklm;
        public static DPFZ6_ijklmn PFZ6_ijklmn;
        public static DGFG6_iii GFG6_iii;
        public static DGFG6_iij GFG6_iij;
        public static DGFG6_ijk GFG6_ijk;
        public static DPFG6_i PFG6_i;
        public static DPFG6_ij PFG6_ij;
        public static DPFG6_ijk PFG6_ijk;
        public static DGFZ4_iiii GFZ4_iiii;
        public static DGFZ4_iiij GFZ4_iiij;
        public static DGFZ4_iijj GFZ4_iijj;
        public static DGFZ4_iijk GFZ4_iijk;
        public static DGFZ4_ijkl GFZ4_ijkl;
        public static DPFZ4_i PFZ4_i;
        public static DPFZ4_ij PFZ4_ij;
        public static DPFZ4_ijk PFZ4_ijk;
        public static DPFZ4_ijkl PFZ4_ijkl;
        public static DGFG4_ii GFG4_ii;
        public static DGFG4_ij GFG4_ij;
        public static DPFG4_i PFG4_i;
        public static DPFG4_ij PFG4_ij;
        public static DPFZ3_i PFZ3_i;
        public static DPFZ3_ij PFZ3_ij;
        public static DPFZ3_ijk PFZ3_ijk;
        public static DPFZ5_i PFZ5_i;
        public static DPFZ5_ij PFZ5_ij;
        public static DPFZ5_ijk PFZ5_ijk;
        public static DPFZ5_ijkl PFZ5_ijkl;
        public static DPFZ5_ijklm PFZ5_ijklm;
        public static DPFZ7_i PFZ7_i;
        public static DPFZ7_ij PFZ7_ij;
        public static DPFZ7_ijk PFZ7_ijk;
        public static DPFZ7_ijkl PFZ7_ijkl;
        public static DPFZ7_ijklm PFZ7_ijklm;
        public static DPFZ7_ijklmn PFZ7_ijklmn;
        public static DPFZ7_ijklmno PFZ7_ijklmno;
        public static DPFZ9_i PFZ9_i;
        public static DPFZ9_ij PFZ9_ij;
        public static DPFZ9_ijk PFZ9_ijk;
        public static DPFZ9_ijkl PFZ9_ijkl;
        public static DPFZ9_ijklm PFZ9_ijklm;
        public static DPFZ9_ijklmn PFZ9_ijklmn;
        public static DPFZ9_ijklmno PFZ9_ijklmno;
        public static DPFZ9_ijklmnop PFZ9_ijklmnop;
        public static DPFZ9_ijklmnopq PFZ9_ijklmnopq;

        #endregion

        #region ENUM

        public enum OperationSystem : int
        {
            Windows,
            Linux,
            MacOSX
        }

        public enum RelationshipEstimator : int
        {
            RelatednessHuang2014,
            RelatednessHuang2015,
            RelatednessRitland1996,
            KinshipRitland1996,
            RelatednessLoiselle1995,
            KinshipLoiselle1995,
            RelatednessHardy1999,
            KinshipWeir1996,
            RelatednessHuangUnpub,
            KinshipHuangUnpub
        }

        public enum FstEstimator : int
        {
            WeightGenoIAM,
            WeightGenoSMM,
            Slatkin1995,
            Nei1973,
            Hudson1992,
            Hedrick2005,
            Jost2008,
            Huang2019,
            SimGenoIAM,
            SimGenoSMM,
            SimNei1973
        }

        public enum JackknifeType : int
        {
            WeightedAverage,
            PairWeightedAverage,
            Likelihood
        }

        public enum HeritabilityEstimator : int
        {
            Ritland1996,
            Mousseau1998,
            Thomas2000,
            HuangRegress,
            HuangML
        }

        public enum SelfingRateEstimator : int
        {
            HuangML,
            HardyFz,
            Hardyg2z,
            HardyFzEM,
            Hardyg2zEM
        }

        public enum WaplesMatingSystem : int
        {
            HS,
            MS,
            ME,
            DR,
            DH
        }

        public enum ParentageEstimateError : int
        {
            NotDone,
            Confidence80,
            Confidence95,
            Confidence99,
            Confidence999
        }

        public enum ParentageOutputStyle : int
        {
            Top1,
            Top2,
            Top5,
            Positive,
            All
        }

        public enum DoubleReductionModel : int
        {
            RCS,
            PRCS,
            CES,
            PES25,
            PES50,
            PESRS
        }

        public enum DiffType : int
        {
            AmongRegsInTot,
            AmongPopsInTot,
            AmongPopsInReg,
            BetweenRegs,
            BetweenPops,
        };

        public enum StructurePlotType : int
        {
            BarPlotOriginal,
            BarPlotGroupByPop,
            BarPlotSortByQ,
            LikelihoodConvergency
        };

        public enum BayesAssPlotType : int
        {
            BarPlotAncestry,
            BarPlotAncestryxAge,
            BarPlotAge,
            BarPlotAncestryGroupbyPop,
            BarPlotAncestryxAgeGroupbyPop,
            BarPlotAgeGroupbyPop,
            logGConvergency,
            logMConvergency,
            logSConvergency
        }

        public enum ColorMode : int
        {
            BarPlotWhiteBackground,//bright
            LinePlotBlackBackground,//light lines
            ScatterPlotWhiteBackground,//darker points
        }

        public enum FstType : int
        {
            Among,
            Between,
        }

        public enum OrdinationType : int
        {
            PCoA,
            PCA
        }

        public enum InputFormat : int
        {
            Phenotype,
            Genotype,
            Genotype1D,
            Genotype1DNoTab,
            Default
        }

        public enum BayesAssType : int
        {
            FixedDummy,
            VariableDummy,
            FixedGenotype,
            VariableGenotype,
            Phenotype
        }

        public enum GlobalRunState : int
        {
            notstart,
            running,
            end,
            simulating,
            simulated,
            simulatedend,
            mantelrunning,
            mantelend,
            mantelbreak
        }

        public enum ParentageSimResult : int
        {
            S1_Success,
            S1_Fail_ParentSampled,
            S1_Fail_ParentUnsampled,
            S1_Fail_None,
            S2_Success,
            S2_Fail_ParentSampled,
            S2_Fail_ParentUnsampled,
            S2_Fail_None,
            S3_Success,
            S3_Fail_PairSampled,
            S3_Fail_MotherUnsampled,
            S3_Fail_FatherUnsampled,
            S3_Fail_PairUnsampled,
            S3_Fail_None,
            S4_Success,
            S4_Fail_PairSampled,
            S4_Fail_OneSampled,
            S4_Fail_PairUnsampled,
            S4_Fail_None
        }

        public enum ParentageMethod : int
        {
            Pheno,
            Exclusion,
            Dominant,
            Geno,
            Sibship
        }
        public enum ExportMethod : int
        {
            Truncate,
            Split,
            Rand
        }

        public enum ExportFormat : int
        {
            PolyGene,
            Genepop,
            Structure,
            PolyRelatedness,
            Spagedi,
            Genodive,
            Migrate,
            BayesAss,
        }
        public enum ClusteringMethod : int
        {
            NEAREST,
            FURTHEST,
            UPGMA,
            UPGMC,
            WPGMA,
            WPGMC,
            WARD
        }
        public enum InbreedingEstimator : int
        {
            KinshipRitland1996,
            KinshipLoiselle1995,
            KinshipWeir1996,
            KinshipHuangUnpub
        }

        #endregion

        #region GLOBALVARS

        public static string DELIM = "/";
        public static float DPI_SCALE = 1.0f;

        public static string[] PLOIDYNAME = new string[] { "None", "Ha", "Di", "Tri", "Tetra", "Oenta", "Hexa", "Septu", "Octo", "Nonu", "Deca", "Hendeca", "Dodeca" };
        public static Color[] PLOIDYCOLOR = new Color[] { Color.White, Color.DarkRed, Color.Red, Color.Black, Color.Blue, Color.FromArgb(200, 100, 0), Color.Orange, Color.DarkGreen, Color.FromArgb(0, 180, 0), Color.DarkMagenta, Color.Magenta, Color.FromArgb(196, 196, 0), Color.Yellow };

        public static bool ISLOADING = false;
        public static Thread THREAD;
        public static Thread THREAD_Ex;
        public static List<Thread> THREAD_LIST = new List<Thread>();
        public static string[] ARGS;
        public static StreamWriter OUTPUT_FREQUENCY;
        public static StreamWriter OUTPUT_DIVERSITY;
        public static StreamWriter OUTPUT_DISTRIBUTION;
        public static StreamWriter OUTPUT_LINKAGE;
        public static StreamWriter OUTPUT_NE;
        public static StreamWriter OUTPUT_DIFFERENTIATION;
        public static StreamWriter OUTPUT_DISTANCE;
        public static StreamWriter OUTPUT_PCOA;
        public static StreamWriter OUTPUT_CLUSTERING;
        public static StreamWriter OUTPUT_INBREEDING;
        public static StreamWriter OUTPUT_HINDEX;
        public static StreamWriter OUTPUT_ASSIGNMENT;
        public static StreamWriter OUTPUT_SPATIAL;
        public static StreamWriter OUTPUT_RELATIONSHIP;
        public static StreamWriter OUTPUT_HERITABILITY;
        public static StreamWriter OUTPUT_QST;
        public static StreamWriter OUTPUT_PARENTAGE_SIMULATION;
        public static StreamWriter OUTPUT_PARENTAGE_PATERNITY;
        public static StreamWriter OUTPUT_PARENTAGE_PARENTPAIR;
        public static StreamWriter OUTPUT_PARENTAGE_UNKNOWN;
        public static StreamWriter OUTPUT_PARENTAGE_ERROR;
        public static StreamWriter OUTPUT_PARENTAGE_SAMPLERATE;
        public static StreamWriter OUTPUT_AMOVA;
        public static StreamWriter OUTPUT_MANTEL;

        //MISC
        public static string IDENTIFIER = "\r\n䬛\r\n";
        public static string IDENTIFIER2 = "\r\n䰥\r\n";
        public static int MAX_PLOIDY = 10;
        public static int MAX_ALLELESID = 65535;
        public static int MAX_ALLELES = 150;
        public static int MAX_LOCI = 16776960;
        public static int MAX_INDS = 16776960;
        public static int MAXBUF = 4096;
        public static int MAX_OUTPUT = 1024 * 1024 * 10;
        public static bool PRESAVE = false;

        public static InputFormat FORMAT = InputFormat.Default;
        public static bool ISGENOTYPE = false;
        private static Random GLOBAL_RND = new Random();
        public static double[,] PHENO_COUNT = new double[MAX_PLOIDY + 1, MAX_ALLELES + 2];//number of phenotypes

        //Calculation
        public static bool CALC_DISTRIBUTION = false;
        public static bool CALC_LINKAGE = false;
        public static bool CALC_NE = false;
        public static bool CALC_DIFF = false;
        public static bool CALC_DIST = false;
        public static bool CALC_ORDINATION = false;
        public static bool CALC_CLUSTERING = false;
        public static bool CALC_INBREEDING = false;
        public static bool CALC_HINDEX = false;
        public static bool CALC_ASSIGNMENT = false;
        public static bool CALC_SPATIAL = false;
        public static bool CALC_RELATIONSHIP = false;
        public static bool CALC_HERITABILITY = false;
        public static bool CALC_QST = false;
        public static bool CALC_PARENTAGE = false;
        public static bool CALC_AMOVA = false;
        public static bool CALC_STRUCTURE = false;
        public static bool CALC_BAYESASS = false;

        //Global
        public static string PHENOTYPE_INPUT = "";
        public static string DECIMAL = "F5";
        public static int SEED = 0;
        public static bool SEED_REFRESH = false;
        public static int N_THREAD = 4;
        public static bool REMIND_WARNING = true;
        public static bool FOLD_CONTROL = true;

        //Simulation
        public static int SIMPOP_NDIS;
        public static double SIMPOP_FST_TERMINAL = 0.05;
        public static bool SIMPOP_DIOECIOUS = false;
        public static double SIMPOP_FEMALE_RATE = 0.5;
        public static double SIMPOP_SELFING_RATIO = 0;
        public static double SIMPOP_BETA_RATIO = 0;
        public static double SIMPOP_SAMPLING_RATIO = 1;
        public static string SIMPOP_DIST = "";
        public static bool SIMPOP_OUTPUT_GENOTYPE = false;

        //Allele frequency
        public static bool REMOVE_DUP_ALLELE = false;
        public static bool DISCARD_EMPTY = true; //Genotype: discard; Phenotype: discard if not consider null allele or negative amplification
        public static bool CONSIDER_NULL = true;
        public static bool CONSIDER_NEGATIVE = true;
        public static bool CONSIDER_SELFING = true;
        public static double NULL_FREQUENCY = 0.1;
        public static int NULL_ALLELE = 0;
        public static SelfingRateEstimator SELFING_ESTIMATOR = SelfingRateEstimator.HuangML;
        public static DoubleReductionModel DR_MODE = DoubleReductionModel.RCS;
        public static double NRRATE = 0.75;

        public static double MAX_EMDIFF = 0.000000001;
        public static int MAX_EMITER = 2000;
        public static double LIKESTOP1 = 1e-8;
        public static double LIKESTOP2 = 1e-11;
        public static double MINALLELEFREQ = 1e-10;
        public static double MINALLELEFREQSQ = 1e-20;
        public static double MAX_ITER_ML = 1200;
        public static double DUNDERFLOW = 1e-100;
        public static double DOVERFLOW = 1e100;

        //Diversity

        //Equilibrium test
        public static bool DISTRIBUTION_TOT = false;
        public static bool DISTRIBUTION_REG = false;
        public static bool DISTRIBUTION_POP = false;

        //Linkage disequilibrium
        public static bool LINKAGE_TOT = false;
        public static bool LINKAGE_REG = false;
        public static bool LINKAGE_POP = false;
        public static bool LINKAGE_FISHER = false;
        public static bool LINKAGE_BURROWS = false;
        public static bool LINKAGE_RAYMOND = false;
        public static int LINKAGE_BURNIN = 10000;
        public static int LINKAGE_BATCHES = 10000;
        public static int LINKAGE_ITERATIONS = 10000;

        //NE
        public static bool NE_NOMURA2008 = false;
        public static bool NE_PUDOVKIN2009 = false;
        public static bool NE_WAPLES2010 = false;
        public static double NE_WAPLES_F = 1;
        public static WaplesMatingSystem NE_WAPLES_MS = WaplesMatingSystem.MS;

        //Genetic differentation
        public static bool DIFF_POP = true;
        public static bool DIFF_REG = false;
        public static bool DIFF_TOT = false;
        public static bool DIFF_Huang2018IAM = false;
        public static bool DIFF_Huang2018SMM = false;
        public static bool DIFF_Slatkin1995 = false;
        public static bool DIFF_Nei1973 = false;
        public static bool DIFF_Hudson1992 = false;
        public static bool DIFF_Hedrick2005 = false;
        public static bool DIFF_Jost2008 = false;
        public static bool DIFF_Huang2019 = false;
        public static bool DIFF_TESTPHENO = false;
        public static bool DIFF_TESTALLELE = false;
        public static bool DIFF_TESTPERM = false;
        public static int DIFF_BURNIN = 10000;
        public static int DIFF_BATCHES = 10000;
        public static int DIFF_ITERATIONS = 10000;

        //Genetic distance
        public static bool DIST_IND = false;
        public static bool DIST_POP = true;
        public static bool DIST_REG = false;
        public static bool DIST_Nei1972 = false;
        public static bool DIST_Cavalli1967 = false;
        public static bool DIST_Reynold1993 = false;
        public static bool DIST_Nei1983 = false;
        public static bool DIST_Euclidean = false;
        public static bool DIST_Goldstein1995 = false;
        public static bool DIST_Nei1973 = false;
        public static bool DIST_Rogers1973 = false;
        public static bool DIST_Sokal1958 = false;
        public static bool DIST_Rogers1960 = false;
        public static bool DIST_Jaccard1901 = false;
        public static bool DIST_Sorensen1948 = false;
        public static bool DIST_Sokal1963 = false;
        public static bool DIST_Russel1940 = false;
        public static bool DIST_Reynolds1983 = false;
        public static bool DIST_Slatkin1995 = false;

        //Ordination
        public static int ORDINATION_NDIM = 3;
        public static bool ORDINATION_PCOA = false;
        public static bool ORDINATION_PCA = false;
        public static int ORDINATION_FONT_SIZE = 12;
        public static int ORDINATION_STYLE = 0;
        public static int ORDINATION_MARKER_SIZE = 12;
        public static string ORDINATION_MARKER = "+✕○●△▲□■⬠⬟⬡⬢";
        public static string ORDINATION_AXES = "1,2";

        //Hierarical clustering
        public static bool CLUSTERING_NEAREST = false;
        public static bool CLUSTERING_FURTHEST = false;
        public static bool CLUSTERING_UPGMA = false;
        public static bool CLUSTERING_UPGMC = false;
        public static bool CLUSTERING_WPGMA = false;
        public static bool CLUSTERING_WPGMC = false;
        public static bool CLUSTERING_WARD = true;
        public static int CLUSTERING_FONT_SIZE = 12;
        public static int CLUSTERING_LINE_SEP = 8;

        //Individual Inbreeding coef
        public static bool INBREEDING_Ritland1996 = false;
        public static bool INBREEDING_Loiselle1995 = false;
        public static bool INBREEDING_Weir1996 = false;
        public static bool INBREEDING_HuangUnpub = true;
        public static bool INBREEDING_JACKKNIFE = false;

        //Individual Hindex

        //Population Assignment
        public static bool ASSIGNMENT_PLOIDY = true;
        public static double ASSIGNMENT_ERROR = 0.01;

        //Spatial Pattern
        public static int SPATIAL_DISTCLASS = 0;
        public static string SPATIAL_DISTINTERVAL = "100";
        public static bool SPATIAL_HAVERSINE = false;
        public static bool SPATIAL_JACKKNIFE = true;

        //Relationship
        public static bool RELATIONSHIP_TOT = false;
        public static bool RELATIONSHIP_REG = false;
        public static bool RELATIONSHIP_POP = false;
        public static bool RELATIONSHIP_Huang2014 = false;
        public static bool RELATIONSHIP_Huang2015 = false;
        public static bool RELATIONSHIP_Ritland1996m = false;
        public static bool RELATIONSHIP_Ritland1996 = false;
        public static bool RELATIONSHIP_Loiselle1995m = false;
        public static bool RELATIONSHIP_Loiselle1995 = false;
        public static bool RELATIONSHIP_Hardy1999 = false;
        public static bool RELATIONSHIP_Weir1996 = false;
        public static bool RELATIONSHIP_HuangUnpubm = false;
        public static bool RELATIONSHIP_HuangUnpub = false;
        public static bool RELATIONSHIP_JACKKNIFE = false;

        //Heritability
        public static bool HERITABILITY_Ritland1996 = false;
        public static bool HERITABILITY_Mousseau1998 = false;
        public static bool HERITABILITY_Thomas2000 = false;
        public static bool HERITABILITY_HuangML = false;
        public static bool HERITABILITY_HuangMOM = false;
        public static bool HERITABILITY_Jackknife = false;

        //Parentage
        public static bool PARENTAGE_SKIPSIM = false;
        public static ParentageEstimateError PARENTAGE_ESTERR = ParentageEstimateError.NotDone;
        public static bool PARENTAGE_ESTSR = false;
        public static bool PARENTAGE_REDO = false;
        public static bool PARENTAGE_PATERNITY = true;
        public static bool PARENTAGE_PARENTPAIR = false;
        public static bool PARENTAGE_UNKNOWN = false;
        public static double PARENTAGE_SAMPLING_RATE = 0.95;
        public static double PARENTAGE_MISTYPE_RATE = 0.01;
        public static int PARENTAGE_NSIM = 10000;
        public static int PARENTAGE_PATERNITY_NFATHER = 50;
        public static int PARENTAGE_PARENTPAIR_NFATHER = 50;
        public static int PARENTAGE_PARENTPAIR_NMOTHER = 50;
        public static int PARENTAGE_ERROR_NSIM = 100000;
        public static int PARENTAGE_UNKNOWN_NCANDIDATE = 50;
        public static ParentageOutputStyle PARENTAGE_OUTPUT = ParentageOutputStyle.Top1;
        public static ParentageMethod PARENTAGE_METHOD = ParentageMethod.Pheno;

        public static string[] PATERNITY_OFFSPRING;
        public static string[] PARENTPAIR_OFFSPRING;
        public static string[] PARENTPAIR_FATHER;
        public static string[] PARENTPAIR_MOTHER;
        public static string[] UNKNOWN_OFFSPRING;
        public static string[] UNKNOWN_PARENT;
        public static double d1_999 = 999, d1_99 = 999, d1_95 = 999, d1_80 = 999;
        public static double d2_999 = 999, d2_99 = 999, d2_95 = 999, d2_80 = 999;
        public static double dPM_999 = 999, dPM_99 = 999, dPM_95 = 999, dPM_80 = 999;
        public static double dPF_999 = 999, dPF_99 = 999, dPF_95 = 999, dPF_80 = 999;
        public static double dP_999 = 999, dP_99 = 999, dP_95 = 999, dP_80 = 999;
        public static double dPU_999 = 999, dPU_99 = 999, dPU_95 = 999, dPU_80 = 999;

        //AMOVA
        public static int AMOVA_PERMUTE = 100000;
        public static bool AMOVA_IAM = false;
        public static bool AMOVA_SMM = false;
        public static bool AMOVA_IGNOREIND = false;
        public static bool AMOVA_OUTPUTSS = false;
        public static bool AMOVA_HOMO = false;
        public static bool AMOVA_HOMO_CORR = false;
        public static bool AMOVA_ANISO = false;
        public static bool AMOVA_ML = false;
        public static bool AMOVA_GENO = false;
        public static string REGIONTEXT = "";

        //Structure
        public static bool STRUCTURE_ADMIXTURE = false;
        public static bool STRUCTURE_LOCPRIORI = false;
        public static bool STRUCTURE_FMODEL = false;
        public static int STRUCTURE_KMIN = 1;
        public static int STRUCTURE_KMAX = 6;

        public static int STRUCTURE_NBURNIN = 5000;
        public static int STRUCTURE_NREPS = 10000;
        public static int STRUCTURE_NTHINNING = 1;
        public static int STRUCTURE_NRUNS = 6;

        public static double STRUCTURE_LAMBDA = 1;
        public static double STRUCTURE_STDLAMBDA = 0.3;
        public static double STRUCTURE_MAXLAMBDA = 10;
        public static int STRUCTURE_ADMBURNIN = 500;
        public static bool STRUCTURE_INFERLAMBDA = false;
        public static bool STRUCTURE_DIFFLAMBDA = false;

        public static double STRUCTURE_ALPHA0 = 1;
        public static double STRUCTURE_STDALPHA = 0.025;
        public static double STRUCTURE_MAXALPHA = 10;
        public static int STRUCTURE_METROFREQ = 10;
        public static bool STRUCTURE_INFERALPHA = true;
        public static bool STRUCTURE_DIFFALPHA = false;
        public static bool STRUCTURE_GAMMAALPHA = false;
        public static double STRUCTURE_ALPHAPRIORA = 0.025;
        public static double STRUCTURE_ALPHAPRIORB = 0.001;

        public static double STRUCTURE_MAXR = 20;
        public static double STRUCTURE_EPSR = 0.1;
        public static double STRUCTURE_EPSETA = 1;
        public static double STRUCTURE_EPSGAMMA = 1;

        public static double STRUCTURE_FPRIORMEAN = 0.01;
        public static double STRUCTURE_FPRIORSTD = 0.05;
        public static double STRUCTURE_FSTDF = 0.05;
        public static bool STRUCTURE_FSAME = false;

        public static StructurePlotType STRUCTURE_STYLE = StructurePlotType.BarPlotOriginal;
        public static bool STRUCTURE_REARRANGE = false;

        //BayesAss
        public static BayesAssType BAYESASS_TYPE;

        public static int BAYESASS_NBURNIN;
        public static int BAYESASS_NREPS;
        public static int BAYESASS_NTHINNING;
        public static int BAYESASS_NRUNS;
        public static bool BAYESASS_NOLIKELIHOOD;

        public static double BAYESASS_DELTAA;
        public static double BAYESASS_DELTAF;
        public static double BAYESASS_DELTAM;

        public static int BAYESASS_SEPARATORWIDTH = 6;
        public static BayesAssPlotType BAYESASS_PLOTSTYLE = BayesAssPlotType.BarPlotAncestry;

        //Mantel
        public static string MANTEL_INPUT = "";
        public static int MANTEL_NPERM = 9999;
        public static int MANTEL_NSIG = 9999;
        public static int MANTEL_CPERM = 9999;


        public static GlobalRunState runstate = GlobalRunState.notstart;
        private static string cdir = "";
        private static string resdir = "";
        public static POP all;
        public static Form1 f1 = null;
        public static Form3 f3;
        public static Form4 f4;
        public static Form5 f5;
        public static Form6 f6;

        #endregion

        #region DELEGATE

        public static void SetProgress(int val, int max)
        {
            Action<int, int> ct = (x, y) =>
            {
                f1.toolStripProgressBar1.Value = 0;
                f1.toolStripProgressBar1.Maximum = y;
                f1.toolStripProgressBar1.Value = x;
            };
            if (f1.FrequencyInheritanceModeBox.InvokeRequired == true)
                f1.FrequencyInheritanceModeBox.Invoke(ct, new object[] { val, max });
            else
                ct(val, max);
        }

        public static void SetText(TextBox tb, string text)
        {
            Action<TextBox, string> ct = (x, y) => x.Text = y;
            if (f1.FrequencyInheritanceModeBox.InvokeRequired == true)
                f1.FrequencyInheritanceModeBox.Invoke(ct, new object[] { tb, text });
            else
                ct(tb, text);
        }

        public static void SetDecimal(NumericUpDown tb, double val)
        {
            Action<NumericUpDown, double> ct = (x, y) => x.Value = (decimal)y;
            if (f1.FrequencyInheritanceModeBox.InvokeRequired == true)
                f1.FrequencyInheritanceModeBox.Invoke(ct, new object[] { tb, val });
            else
                ct(tb, val);
        }

        public static T ShowErrorMessage<T>(string text, string title, T ret)
        {
            Action<string, string> act = (x, y) => { MessageBox.Show(x, y); };
            f1.Invoke(act, new object[] { text, title });
            return ret;
        }

        public static bool ShowMessage3Buttons(string text)
        {
            Func<string, DialogResult> act = (x) =>
            { return MessageBox.Show(x + "\r\n\r\nYes: disable warning in this run; No: continue; Calcel: abort.", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); };
            switch ((DialogResult)f1.Invoke(act, new object[] { text }))
            {
                case DialogResult.Yes: REMIND_WARNING = false; return true;
                case DialogResult.Cancel: return false;
                default: return true;
            }
        }

        #endregion

        #region THREAD_CONTROL

        public delegate void ThreadFunc(object obj);

        public static object[] PrepareThreadParam(int id, int nthreads, object[] val)
        {
            object[] re = new object[val.Length + 2];
            re[0] = id;
            re[1] = nthreads;
            for (int i = 0; i < val.Length; ++i)
                re[i + 2] = val[i];
            return re;
        }

        public static void CallThread(ThreadFunc func, int nthreads, object obj, int cend, ref int progress)
        {
            object[] obj2 = (object[])obj;
            Thread[] threads = new Thread[nthreads];

            for (int i = 0; i < nthreads; ++i)
            {
                Thread th = new Thread(new ParameterizedThreadStart(func));
                th.Start(PrepareThreadParam(i, nthreads, obj2));
                THREAD_LIST.Add(th);
                threads[i] = th;
            }

            for (; ; )
            {
                if (progress == cend) break;
                Thread.Sleep(42);
            }

            foreach (Thread th in threads)
                THREAD_LIST.Remove(th);
        }

        private void FoldTimer_Tick(object sender, EventArgs e)
        {
            if (SIZE_CHANGED) ShowPanel();
            if (PLOT_BAYESASS) PlotBayesAss();
            if (PLOT_STRUCTURE) PlotStructure();
        }

        private void PreSaveTimerTick(object sender, EventArgs e)
        {
            if (PRESAVE) SaveSettings();
        }
        #endregion

        #region COLOR

        private static Color HSV2RGB(double H, double S, double V)
        {
            double R = 0, G = 0, B = 0;
            double h = H / 60;
            double f = h - (int)Math.Floor(h);
            double p = V * (1.0 - S);
            double q = V * (1.0 - f * S);
            double t = V * (1.0 - (1.0 - f) * S);

            switch (((int)h) % 6)
            {
                case 0: R = 255.0 * V; G = 255.0 * t; B = 255.0 * p; break;
                case 1: R = 255.0 * q; G = 255.0 * V; B = 255.0 * p; break;
                case 2: R = 255.0 * p; G = 255.0 * V; B = 255.0 * t; break;
                case 3: R = 255.0 * p; G = 255.0 * q; B = 255.0 * V; break;
                case 4: R = 255.0 * t; G = 255.0 * p; B = 255.0 * V; break;
                case 5: R = 255.0 * V; G = 255.0 * p; B = 255.0 * q; break;
            }
            return Color.FromArgb((int)R, (int)G, (int)B);
        }

        private static Color[] GetDarkColor(int n)
        {
            int nc = 0;
            double nsep = 0;
            Color[] re = new Color[n];
            double[] S = new double[] { 1.00, 0.75, 0.50, 0.25, 1.00, 0.75, 0.50, 0.25, 1.00, 0.75, 0.50, 0.25, 1.00, 0.75, 0.50, 0.25 };
            double[] B = new double[] { 0.75, 0.75, 0.75, 0.75, 0.50, 0.50, 0.50, 0.50, 0.25, 0.25, 0.25, 0.25, 0.05, 0.05, 0.05, 0.05 };

            if (n < S.Length * 6)
                nc = 6;
            else if (n < S.Length * 12)
                nc = 12;
            else if (n < S.Length * 18)
                nc = 18;
            else if (n < S.Length * 24)
                nc = 24;
            else if (n < S.Length * 30)
                nc = 30;
            else if (n < S.Length * 36)
                nc = 36;

            nsep = 360.0 / nc;
            int c = 0;
            for (int i = 0; i < S.Length; ++i)
            {
                for (int j = 0; j < nc; ++j)
                {
                    re[c++] = HSV2RGB(j * nsep, S[i], B[i]);
                    if (c == n) return re;
                }
            }
            return re;
        }

        private static Color[] GetColor(int n, ColorMode m)
        {
            int nc = 0;
            double nsep = 0;
            Color[] re = new Color[n];
            double[] S = null, B = null, St = null, Bt = null;
            if (n > 588)
            {
                switch (m)
                {
                    case ColorMode.BarPlotWhiteBackground:
                        St = new double[] { 1.0, 0.8, 0.6, 0.4, 0.2, 0.9, 0.7, 0.5, 0.3, 0.1 };
                        Bt = new double[] { 1.0, 0.8, 0.6, 0.4, 0.2, 0.9, 0.7, 0.5, 0.3, 0.1 };
                        break;
                    case ColorMode.LinePlotBlackBackground:
                        St = new double[] { 0.2, 0.4, 0.6, 0.8, 1.0, 0.1, 0.3, 0.5, 0.7, 0.9 };
                        Bt = new double[] { 1.0, 0.8, 0.6, 0.4, 0.2, 0.9, 0.7, 0.5, 0.3, 0.1 };
                        break;
                    case ColorMode.ScatterPlotWhiteBackground:
                        St = new double[] { 1.0, 0.8, 0.6, 0.4, 0.2, 0.9, 0.7, 0.5, 0.3, 0.1 };
                        Bt = new double[] { 0.8, 0.6, 0.4, 0.2, 0.9, 0.7, 0.5, 0.3 };
                        break;
                }
            }
            else if (n > 192 && n <= 588)
            {
                switch (m)
                {
                    case ColorMode.BarPlotWhiteBackground:
                        St = new double[] { 1.0, 0.7, 0.4, 0.1, 0.85, 0.55, 0.25 };
                        Bt = new double[] { 1.0, 0.7, 0.4, 0.1, 0.85, 0.55, 0.25 };
                        break;
                    case ColorMode.LinePlotBlackBackground:
                        St = new double[] { 0.1, 0.4, 0.7, 1.0, 0.25, 0.55, 0.85 };
                        Bt = new double[] { 1.0, 0.7, 0.4, 0.1, 0.85, 0.55, 0.25 };
                        break;
                    case ColorMode.ScatterPlotWhiteBackground:
                        St = new double[] { 1.0, 0.7, 0.4, 0.1, 0.85, 0.55, 0.25 };
                        Bt = new double[] { 0.7, 0.5, 0.3, 0.1, 0.80, 0.60, 0.40 };
                        break;
                }
            }
            else if (n <= 192)
            {
                switch (m)
                {
                    case ColorMode.BarPlotWhiteBackground:
                        St = new double[] { 1.0, 0.8, 0.6, 0.4 };
                        Bt = new double[] { 1.0, 0.8, 0.6, 0.4 };
                        break;
                    case ColorMode.LinePlotBlackBackground:
                        St = new double[] { 0.3, 0.7, 0.1, 0.5 };
                        Bt = new double[] { 1.0, 0.8, 0.6, 0.4 };
                        break;
                    case ColorMode.ScatterPlotWhiteBackground:
                        St = new double[] { 1.0, 0.8, 0.6, 0.4 };
                        Bt = new double[] { 0.8, 0.65, 0.5, 0.35 };
                        break;
                }
            }

            S = new double[St.Length * Bt.Length];
            B = new double[St.Length * Bt.Length];
            for (int i = 0, cp = 0; i < St.Length; ++i)
                for (int j = 0; j < Bt.Length; ++j, ++cp)
                {
                    B[cp] = Bt[i];
                    S[cp] = St[j];
                }

            if (n < S.Length * 6)
                nc = 6;
            else if (n < S.Length * 12)
                nc = 12;
            else
                nc = (int)Math.Ceiling(n / (double)S.Length);

            nsep = 360.0 / nc;
            int c = 0;
            for (int i = 0; i < S.Length; ++i)
            {
                for (int j = 0; j < nc; ++j)
                {
                    re[c++] = HSV2RGB(j * nsep, S[i], B[i]);
                    if (c == n) return re;
                }
            }
            return re;
        }

        private static Color GetDarkerColor(Color c, double coef = 0.9)
        {
            return Color.FromArgb((int)(c.R * coef), (int)(c.G * coef), (int)(c.B * coef));
        }

        #endregion

        #region DATA

        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct FastLog
        {
            [FieldOffset(0)]
            private double vlog;
            [FieldOffset(8)]
            public double vlinear;
            [FieldOffset(12)]
            private int vlinearu;

            public double v1
            {
                get { return vlinear == 1 ? vlog : Close(); }
            }

            public static FastLog Default = new FastLog(0, 1);

            public FastLog(double _v1, double _v2)
            {
                vlinearu = 0;
                vlog = _v1;
                vlinear = _v2;
            }

            public void Charge(double val)
            {
                vlinear *= val;
                if (vlinear < DUNDERFLOW || vlinear > DOVERFLOW)
                {
                    vlog += ((vlinearu << 1) >> 21) - 1023;
                    vlinearu &= -2146435073;
                    vlinearu |= 0x3FF00000;
                }
            }

            public void ChargeOld(double val)
            {
                double vp = vlinear * val;
                if (vp < DUNDERFLOW || vp > DOVERFLOW)
                {
                    vlog += Math.Log(vp);
                    vlinear = 1;
                }
                else
                    vlinear = vp;
            }


            public double Close()
            {
                vlog = vlog * 0.6931471805599453 + MyLog(vlinear);
                vlinear = 1;
                return vlog;
            }

            public void Open()
            {
                vlog = 0;
                vlinear = 1;
            }

            public static void Open(FastLog[] flog)
            {
                for (int i = 0; i < flog.Length; ++i)
                    flog[i].Open();
            }

            public static void Charge(FastLog[] fastlog, double[] val)
            {
                for (int i = 0; i < fastlog.Length; ++i)
                    fastlog[i].Charge(val[i]);
            }

            public static void Close(FastLog[] fastlog)
            {
                foreach (FastLog f in fastlog)
                    f.Close();
            }
        }

        public struct Thomas2000SibRateEntry
        {
            public double fs;
            public double hs;

            public Thomas2000SibRateEntry(double _fs, double _hs)
            {
                fs = _fs;
                hs = _hs;
            }
        }

        public struct Nomura2008NrRateEntry : IComparable<Nomura2008NrRateEntry>
        {
            public double a, b, w;

            public Nomura2008NrRateEntry(double _a, double _b, double _w)
            {
                a = _a;
                b = _b;
                w = _w;
            }

            public void SetVal(double _a, double _b, double _w)
            {
                a = _a;
                b = _b;
                w = _w;
            }

            public int CompareTo(Nomura2008NrRateEntry y)
            {
                return a.CompareTo(y.a);
            }
        }

        private struct FDREntry
        {
            public double p;
            public int id;
            public int rank;

            public void SetVal(double _p, int _id)
            {
                p = _p;
                id = _id;
            }
        }

        private string ToIntegerString(string a)
        {
            StringBuilder re = new StringBuilder();
            foreach (char b in a)
                if (b >= '0' && b <= '9')
                    re.Append(b);
            return re.ToString();
        }

        private static string[,] StringToMatrix(string a)
        {
            int i = 0, j = 0;
            try
            {
                string[] row = a.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] header = row[0].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int m = row.Length, n = header.Length;
                string[,] re = new string[m, n];
                for (i = 0; i < m; ++i)
                {
                    string[] line = row[i].Split(new char[] { '\t' }, StringSplitOptions.None);
                    for (j = 0; j < n; ++j)
                        re[i, j] = line[j];
                    for (; j < line.Length; ++j)
                        if (line[j] != "")
                            return ShowErrorMessage("Input table has different number of columns, at row " + (i + 1) + ".", "Error", (string[,])null);
                }
                return re;
            }
            catch
            {
                return ShowErrorMessage("Error reading input matrices, at line " + (i + 1).ToString() + " column " + (j + 1).ToString(), "Error", (string[,])null);
            }
        }

        public static long GetFileSize(string path)
        {
            if (!File.Exists(path)) return -1;
            return new FileInfo(path).Length;
        }

        public static Dictionary<T, double> CloneKey<T>(Dictionary<T, double> source)
        {
            Dictionary<T, double> newList = new Dictionary<T, double>(source.Count);
            foreach (T item in source.Keys)
                newList[item] = 0;
            return newList;
        }

        public static double Truncate(double min, double max, double val)
        {
            return val < min ? min : (val > max ? max : val);
        }

        public static Dictionary<T1, T2> Clone<T1, T2>(Dictionary<T1, T2> source)
        {
            Dictionary<T1, T2> newList = new Dictionary<T1, T2>(source.Count);
            foreach (T1 item in source.Keys)
                newList[item] = source[item];
            return newList;
        }

        public static List<T> Clone<T>(List<T> source)
        {
            List<T> newList = new List<T>(source.Count);
            foreach (T item in source)
                newList.Add(item);
            return newList;
        }

        public static T[] Clone<T>(T[] source)
        {
            T[] newList = new T[source.Length];
            Array.Copy(source, newList, source.Length);
            return newList;
        }

        public static T[,] Clone<T>(T[,] source)
        {
            int m = source.GetLength(0);
            int n = source.GetLength(1);
            T[,] newList = new T[m, n];
            Array.Copy(source, newList, m * n);
            return newList;
        }

        public static T[] Concatenate<T>(T[] s1, T[] s2)
        {
            T[] newList = new T[s1.Length + s2.Length];
            Array.Copy(s1, 0, newList, 0, s1.Length);
            Array.Copy(s2, 0, newList, s1.Length, s2.Length);
            return newList;
        }

        private static double GetMissingFreq(SUBPOP tp, int l, int a)
        {
            if (tp.loc[l].nhaplotypes == 0 && tp.region != null)
                return GetDictionaryValue(all.total_pop.loc[l].freq, a);
                //return GetMissingFreq(tp.region, l, a);
            return GetDictionaryValue(tp.loc[l].freq, a);
        }

        private static double GetMissingFreq(IND ti, int l, int a)
        {
            if (ti.g[l].hash == 0)//ok
                return GetDictionaryValue(all.total_pop.loc[l].freq, a);
                //return GetMissingFreq(ti.subpop, l, a);
            return GetDictionaryValue(ti.g[l].freq, a);
        }

        public static double GetDictionaryValue<T>(IDictionary<T, double> dict, T key)
        {
            return dict.ContainsKey(key) ? dict[key] : 0;
        }

        private static int GetDictionaryValue<T>(IDictionary<T, int> dict, T key)
        {
            return dict.ContainsKey(key) ? dict[key] : 0;
        }

        private static void Unify(IDictionary<int, double> a, double minfreq = -1)
        {
            if (minfreq == -1) minfreq = MINALLELEFREQ;
            double s = 1.0 / (a.Values.Sum() + a.Count * minfreq);
            foreach (int k in a.Keys.ToArray())
                a[k] = (a[k] + minfreq) * s;
        }

        private static void Unify(List<double> a, double minfreq = -1)
        {
            if (minfreq == -1) minfreq = MINALLELEFREQ;
            int n = a.Count;
            double s = 1.0 / (a.Sum() + n * minfreq);
            for (int i = 0; i < n; ++i)
                a[i] = (a[i] + minfreq) * s;
        }

        private static void Unify(double[] a, double minfreq = -1)
        {
            if (minfreq == -1) minfreq = MINALLELEFREQ;
            int n = a.Length;
            double s = 1.0 / (a.Sum() + n * minfreq);
            for (int i = 0; i < n; ++i)
                a[i] = (a[i] + minfreq) * s;
        }

        private unsafe static void Unify(double[,] a, double minfreq = -1)
        {
            if (minfreq == -1) minfreq = MINALLELEFREQ;
            int m = a.GetLength(0), n = a.GetLength(1);
            for (int i = 0; i < m; ++i)
            {
                double s = 1.0 / (Sum(a, i, 1, 0, n) + n * minfreq);
                for (int j = 0; j < n; ++j)
                    a[i, j] = (a[i, j] + minfreq) * s;
            }
        }

        private static void AddSec(double[,] a, int ai, double[,] b, int bi, int st, int n)
        {
            n += st;
            for (int i = st; i < n; ++i)
                a[ai, i] += b[bi, i];
        }

        private static double SumSquare<T>(IDictionary<T, double> a)
        {
            double s = 0;
            foreach (double v in a.Values)
                s += v * v;
            return s;
        }

        public static double SumRow(double[,] a, int r)
        {
            double sum = 0;
            int n = a.GetLength(1);
            for (int j = 0; j < n; ++j)
                sum += a[r, j];
            return sum;
        }

        public static double SumColumn(double[,] a, int c)
        {
            double sum = 0;
            int m = a.GetLength(0);
            for (int i = 0; i < m; ++i)
                sum += a[i, c];
            return sum;
        }

        private unsafe static double Sum(double* a, int n)
        {
            double re = 0;
            for (int i = 0; i < n; ++i)
                re += a[i];
            return re;
        }

        public static double Sum(double[,] a, int ist, int ilen, int jst, int jlen)
        {
            ilen = Math.Min(a.GetLength(0), ist + ilen);
            jlen = Math.Min(a.GetLength(1), jst + jlen);
            double sum = 0;
            for (int i = ist; i < ilen; ++i)
                for (int j = jst; j < jlen; ++j)
                    sum += a[i, j];
            return sum;
        }

        public static double SumProd<T>(IDictionary<T, double> px, IDictionary<T, double> py)
        {
            double sum = 0;
            foreach (var kv in px)
                if (py.ContainsKey(kv.Key))
                    sum += kv.Value * py[kv.Key];
            return sum;
        }

        public static double SumProd(double[,] a, int ai, double[,] b, int bi, int st, int n)
        {
            double sum = 0;
            for (int i = 0; i < n; ++i)
                sum += a[ai, st + i] * b[bi, st + i];
            return sum;
        }

        public static double SumProd(double[,] A, int ai, double[,] clu, int K, double[,] h, int hid, int st, int k2)
        {
            double re = 0;
            for (int i = 0; i < K; ++i)
                re += A[ai, i] * SumProd(clu, i, h, hid, st, k2);
            return re;
        }

        public static void AddSquare<T>(IDictionary<T, double> fre1, IDictionary<T, double> fre2, IDictionary<T, double> fre3)
        {
            foreach (var kv in fre3)
                fre1[kv.Key] = fre2[kv.Key] + kv.Value * kv.Value;
        }

        public static void AddSquare(double[] a, double[] b, double[] c)
        {
            int m = c.GetLength(0);
            for (int i = 0; i < m; ++i)
                a[i] = b[i] + c[i] * c[i];
        }

        public static void AddSquare(double[,] a, double[,] b, double[,] c)
        {
            int m = c.GetLength(0), n = c.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = b[i, j] + c[i, j] * c[i, j];
        }

        public static void AddById(double[,] a, double[,] b, double[,] c, int[] id, int idaxis)
        {
            int m = c.GetLength(0), n = c.GetLength(1);
            if (idaxis == 0)
            {
                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        a[i, j] = b[i, j] + c[id[i], j];
            }
            else
            {
                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        a[i, j] = b[i, j] + c[i, id[j]];
            }
        }

        public static void Add(double[,] a, int ai, double[,] b, int bi, int st, int n)
        {
            n += st;
            for (int j = st; j < n; ++j)
                a[ai, j] += b[bi, j];
        }

        public static void Add<T>(IDictionary<T, double> fre1, IDictionary<T, double> fre2, IDictionary<T, double> fre3)
        {
            foreach (var p in fre3)
                fre1[p.Key] = fre2[p.Key] + p.Value;
        }

        public static void Add(int[] a, int[] b, int[] c)
        {
            int m = c.GetLength(0);
            for (int i = 0; i < m; ++i)
                a[i] = b[i] + c[i];
        }

        public static void Add(double[] a, double[] b, double[] c)
        {
            int m = c.GetLength(0);
            for (int i = 0; i < m; ++i)
                a[i] = b[i] + c[i];
        }

        public static void Add(double[,,] a, double[,,] b, int id1, int id2, double[] c)
        {
            int m = c.GetLength(0);
            for (int i = 0; i < m; ++i)
                a[id1, id2, i] = b[id1, id2, i] + c[i];
        }

        public static void Add(double[,] a, double[,] b, double[,] c)
        {
            int m = c.GetLength(0), n = c.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = b[i, j] + c[i, j];
        }

        public static void Add(double[,,,] a, double[,,,] b, int id1, int id2, double[,] c)
        {
            int m = c.GetLength(0), n = c.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[id1, id2, i, j] = b[id1, id2, i, j] + c[i, j];
        }

        public static void Add(double[] a, int ao, double[] b, int bo, double[] c, int co, int n)
        {
            for (int j = 0; j < n; ++j)
                a[ao + j] = b[bo + j] + c[co + j];
        }

        public static void Add(double[] a, int ao, double[] b, int bo, double[,] c)
        {
            int m = c.GetLength(0), n = c.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[ao++] = b[bo++] + c[i, j];
        }

        public static void Div(double[] a, double[] b, double[] c)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] = b[i] / c[i];
        }

        public static void Div(double[] a, double[] b, int[] c)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] = b[i] / c[i];
        }

        public static void Div(double[,] a, double[,] b, int[,] c)
        {
            int m = a.GetLength(0), n = a.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = b[i, j] / c[i, j];
        }

        public static void Mul<T>(IDictionary<T, double> a, IDictionary<T, double> b, double val)
        {
            foreach (T k in b.Keys.ToArray())
                a[k] = b[k] * val;
        }

        public static void Mul<T>(IDictionary<T, double> a, IDictionary<T, double> b, IDictionary<T, double> c)
        {
            foreach (T k in b.Keys.ToArray())
                a[k] = b[k] * c[k];
        }

        public static void Mul(double[] a, double[] b, double val)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] = b[i] * val;
        }

        public static void Mul(double[,] a, double[,] b, double val)
        {
            int m = a.GetLength(0), n = a.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = b[i, j] * val;
        }

        public static void Mul(double[,] a, int ai, double[] b, double val)
        {
            int n = b.Length;
            for (int i = 0; i < n; ++i)
                a[ai, i] = b[i] * val;
        }

        public static void AddMul(double[] a, double[,] b, int ai, double c)
        {
            //A[i] += B[i] * C
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] += b[ai, i] * c;
        }

        public static void AddMul(double[] a, double[] b, double[] c)
        {
            //A[i] += B[i] * C[i]
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] += b[i] * c[i];
        }

        public static void AddMul<T>(IDictionary<T, double> a, IDictionary<T, double> b, int c)
        {
            //A[i] += B[i] * C
            foreach (var k in b)
                a[k.Key] += c * b[k.Key];
        }

        public static double SubLogProdCol(double[,] a, int aj, double[,] b, int bj, int n)
        {
            FastLog flog = new FastLog();
            for (int i = 0; i < n; ++i)
                flog.Charge(a[i, aj] / b[i, bj]);
            return flog.Close();
        }

        public static double LogProd(double[,] a, int ist, int ilen, int jst, int jlen)
        {
            ilen = Math.Min(a.GetLength(0), ist + ilen);
            jlen = Math.Min(a.GetLength(1), jst + jlen);
            FastLog flog = FastLog.Default;
            for (int i = ist; i < ilen; ++i)
                for (int j = jst; j < jlen; ++j)
                    flog.Charge(a[i, j]);
            return flog.Close();
        }

        public static double LogProd(double[] a, int ist, int ilen)
        {
            ilen = Math.Min(a.Length, ist + ilen);
            FastLog flog = FastLog.Default;
            for (int i = ist; i < ilen; ++i)
                flog.Charge(a[i]);
            return flog.Close();
        }

        public static void SetVal<T>(T[] a, T val)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
                a[i] = val;
        }

        public static void SetVal<T1, T2>(IDictionary<T1, T2> a, T2 val)
        {
            foreach (T1 k in a.Keys.ToArray())
                a[k] = val;
        }

        public static void SetVal<T>(T[,] a, T val)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    a[i, j] = val;
        }

        public static void SetVal<T>(T[,,] a, T val)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int o = a.GetLength(2);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    for (int k = 0; k < o; ++k)
                        a[i, j, k] = val;
        }

        public static void SetVal<T>(T[,] a, int i, T val)
        {
            int n = a.GetLength(1);
            for (int j = 0; j < n; ++j)
                a[i, j] = val;
        }

        public static void SetVal<T>(T[] a, T[] b, int st, int n)
        {
            n = Math.Min(a.Length, n + st);
            for (int i = st; i < n; ++i)
                a[i] = b[i];
        }

        public static void SetVal<T>(T[,] a, int i, T[] val)
        {
            int n = a.GetLength(1);
            for (int j = 0; j < n; ++j)
                a[i, j] = val[j];
        }

        public static void SetVal<T1, T2>(IDictionary<T1, T2> a, IDictionary<T1, T2> r, T2 val)
        {
            foreach (T1 v in r.Keys)
                a[v] = val;
        }

        #endregion

        #region STATISTICS

        public static int NextAvoid(Random rnd, int n, int a)
        {
            // Generate a random integer ranges from 0 to n-1, and avoid a
            int re = rnd.Next(n - 1);
            if (re >= a) re++;
            return re;
        }

        private static double MyExp(double v)
        {
            return v > -36 ? Math.Exp(v) : 0;
        }

        private static double MyLog(double val)
        {
            if (val < DUNDERFLOW)
                return -2.3025850929940500E+02;
            else if (val > DOVERFLOW)
                return 2.3025850929940500E+02;
            return Math.Log(val);
        }

        private static double[] FDRCorrection(double[] P)
        {
            // False discovery rate correction 
            int n = P.Count(p => !double.IsNaN(p) && !double.IsInfinity(p));//remove invalid cases
            FDREntry[] t = new FDREntry[n];
            for (int i = 0, pc = 0; i < P.Length; ++i)
            {
                if (double.IsNaN(P[i]) || double.IsInfinity(P[i])) continue;
                t[pc++].SetVal(P[i], i);
            }
            Array.Sort(t, (x, y) => x.p.CompareTo(y.p));//sort cases by P

            //Use highest rank for ties
            for (int i = 0, j = 0; i < t.Length; ++i)
            {
                for (j = i + 1; j < t.Length && t[i].p == t[j].p; j++) ;
                for (; i < j; ++i) t[i].rank = j;
                i--;
            }

            double[] re = new double[P.Length];
            SetVal(re, double.NaN);
            double last = 1;
            for (int i = n - 1; i >= 0; --i)
            {
                re[t[i].id] = Math.Min(1, n * t[i].p / t[i].rank);
                if (re[t[i].id] > last) re[t[i].id] = last;
                last = re[t[i].id];
            }
            return re;
        }

        public static void Permute<T>(IList<T> array, Random rnd, int n = -1)
        {
            // Randomly permute elements in the array, using the Fisher-Yates shuffle
            for (int i = n == -1 ? array.Count : n; i > 1; --i)
            {
                int rid = rnd.Next(i);
                T tv = array[i - 1];
                array[i - 1] = array[rid];
                array[rid] = tv;
            }
        }
        /*
        public static List<T> Permute<T>(IList<T> list, Random rnd)
        {
            // Randomly permute elements in the list, using the Fisher-Yates shuffle
            List<T> re = new List<T>(list.Count);
            re.AddRange(list);
            for (int i = re.Count; i > 1; --i)
            {
                int id = rnd.Next(i);
                T t = re[i - 1];
                re[i - 1] = re[id];
                re[id] = t;
            }
            return re;
        }
        */

        public static int[] GetIdxSeq(int n)
        {
            // Generate an index array
            int[] idx = new int[n];
            for (int i = 0; i < n; ++i)
                idx[i] = i;
            return idx;
        }

        public static void GetRandSeq(int[] val, Random rnd, int n = -1)
        {
            // Generate a random sequence with elements range from 0 to n-1 and
            // each integer appears exactly once, uing Fisher-Yates shuffle
            n = n == -1 ? val.Length : n;
            for (int i = 0; i < n; ++i)
                val[i] = i;
            for (int i = n; i > 1; --i)
            {
                int j = rnd.Next(i), t = val[i - 1];
                val[i - 1] = val[j];
                val[j] = t;
            }
        }

        public static void GetRandSeq(int[,] val, Random rnd)
        {
            // Two Dimensional GetRandSeq
            // For each row, generate a random sequence with elemnts range from 0 to n-1 and
            // each integer appears exactly ones, uing Fisher-Yates shuffle
            int m = val.GetLength(0), n = val.GetLength(1);
            for (int i = 0; i < m; ++i)
                for (int j = 0; j < n; ++j)
                    val[i, j] = j;

            for (int i = 0; i < m; ++i)
                for (int j = n; j > 1; --j)
                {
                    int k = rnd.Next(j), t = val[i, j - 1];
                    val[i, j - 1] = val[i, k];
                    val[i, k] = t;
                }
        }

        public static void Swap<T>(ref T val1, ref T val2)
        {
            // Swap the values between two variables
            T t = val1;
            val1 = val2;
            val2 = t;
        }

        public static void SwapRow<T>(T[,] x, int r1, int r2)
        {
            // Swap two rows in a 2D array
            if (r1 == r2) return;
            int m = x.GetLength(0), n = x.GetLength(1);
            for (int j = 0; j < n; ++j)
            {
                T t = x[r1, j];
                x[r1, j] = x[r2, j];
                x[r2, j] = t;
            }
        }

        public static void SwapColumn<T>(T[,] x, int c1, int c2)
        {
            // Swap two columns in a 2D array
            if (c1 == c2) return;
            int m = x.GetLength(0), n = x.GetLength(1);
            for (int i = 0; i < m; ++i)
            {
                T t = x[i, c1];
                x[i, c1] = x[i, c2];
                x[i, c2] = t;
            }
        }

        public static void SwapRowColumn<T>(T[,] x, int rc1, int rc2)
        {
            // Swap rows and columns simultaneously in a 2D array
            if (rc1 == rc2) return;
            SwapRow(x, rc1, rc2);
            SwapColumn(x, rc1, rc2);
        }

        // Buffering binomial coefficients
        public static double[,] BINOMIAL;

        public static double Factorial(int n)
        {
            // factorial of integer n
            switch (n)
            {
                case 0: return 1;
                case 1: return 1;
                case 2: return 2;
                case 3: return 6;
                case 4: return 24;
                case 5: return 120;
                case 6: return 720;
                case 7: return 5040;
                case 8: return 40320;
                case 9: return 362880;
                case 10: return 3628800;
                case 11: return 39916800;
                case 12: return 479001600;
                case 13: return 6227020800;
                case 14: return 87178291200;
                case 15: return 1307674368000;
                case 16: return 20922789888000;
                case 17: return 355687428096000;
                case 18: return 6402373705728000;
                case 19: return 121645100408832000;
                case 20: return 2432902008176640000;
                case 21: return 51090942171709440000.0;
                case 22: return 1124000727777607680000.0;
                case 23: return 25852016738884976640000.0;
                case 24: return 620448401733239439360000.0;
                default:
                    double re = 620448401733239439360000.0;
                    for (int i = 25; i <= n; ++i)
                        re *= i;
                    return re;
            }
        }

        public static double Binomial(int n, int r)
        {
            // Binomial coefficients for integers
            return Factorial(n) / Factorial(r) / Factorial(n - r);
        }

        public static double BinomialLn(double n, double r)
        {
            // Natual logarithm of binomial coefficients for reals
            return GammaLn(n + 1) - GammaLn(n - r + 1) - GammaLn(r + 1);
        }

        public static double BetaLn(double a, double b)
        {
            // Natual logarithm of Beta function
            return GammaLn(a) + GammaLn(b) - GammaLn(a + b);
        }

        public static double BetaLn(double x, double a, double b)
        {
            // Natual logarithm of incomplete beta function
            //https://github.com/codeplea/incbeta/blob/master/incbeta.c
            double STOP = 1.0e-8, TINY = 1.0e-30;
            if (x < 0.0 || x > 1.0)
                return 1.0 / 0.0;

            bool reflag = false;
            if (x > (a + 1) / (a + b + 2))
            {
                x = 1 - x;
                double t = a;
                a = b;
                b = t;
                reflag = true;
            }

            double lbeta_ab = GammaLn(a) + GammaLn(b) - GammaLn(a + b);
            double front = Math.Exp(Math.Log(x) * a + Math.Log(1.0 - x) * b - lbeta_ab) / a;
            double f = 1.0, c = 1.0, d = 0.0;

            for (int i = 0; i <= 200; ++i)
            {
                int m = i / 2;
                double numerator = i == 0 ? 1 : (
                    i % 2 == 0 ? (m * (b - m) * x) / ((a + 2.0 * m - 1.0) * (a + 2.0 * m))
                    : -((a + m) * (a + b + m) * x) / ((a + 2.0 * m) * (a + 2.0 * m + 1)));

                d = 1.0 + numerator * d;
                if (Math.Abs(d) < TINY) d = TINY;
                d = 1.0 / d;

                c = 1.0 + numerator / c;
                if (Math.Abs(c) < TINY) c = TINY;

                f *= c * d;
                if (Math.Abs(1.0 - c * d) < STOP)
                    return reflag ?
                        Math.Log(1 - front * (f - 1.0)) + lbeta_ab :
                        Math.Log(front * (f - 1.0)) + lbeta_ab;
            }
            return 1.0 / 0.0;
        }

        public static double Multinomial(int n, int[] r)
        {
            // Multinomial coefficient
            double re = 1;
            foreach (int a in r)
                re *= Factorial(a);
            return Factorial(n) / re;
        }

        public static double Multinomial(int n, IDictionary<int, int> r)
        {
            // Multinomial coefficient
            double re = 1;
            foreach (int a in r.Values)
                re *= Factorial(a);
            return Factorial(n) / re;
        }

        public static double NormalDistPDF(double x)
        {
            // Probability density function for standard normal distribution
            return 0.3989422804014327 * Math.Exp(-0.5 * x * x);
        }

        public static double NormalDistPDF(double x, double mu, double sigma)
        {
            // Probability density function for normal distribution
            return NormalDistPDF((x - mu) / sigma) / sigma;
        }

        public static double NormalDistCDF(double x)
        {
            // Cumulative distribution function for standard normal distribution
            double A1 = 0.31938153;
            double A2 = -0.356563782;
            double A3 = 1.781477937;
            double A4 = -1.821255978;
            double A5 = 1.330274429;
            double RSQRT2PI = 0.3989422804014327;
            double K = 1.0 / (1.0 + 0.2316419 * Math.Abs(x));
            double cnd = RSQRT2PI * Math.Exp(-0.5 * x * x) * (K * (A1 + K * (A2 + K * (A3 + K * (A4 + K * A5)))));
            if (x > 0) cnd = 1.0 - cnd;
            return cnd;
        }

        public static double NormalDistCDF(double x, double mu, double sigma)
        {
            // Cumulative distribution function for normal distribution
            return NormalDistCDF((x - mu) / sigma);
        }

        public static double[] NormDistICDF_a = new double[] { 2.50662823884, -18.61500062529, 41.39119773534, -25.44106049637 };
        public static double[] NormDistICDF_b = new double[] { -8.47351093090, 23.08336743743, -21.06224101826, 3.13082909833 };
        public static double[] NormDistICDF_c = new double[] { 0.3374754822726147, 0.9761690190917186, 0.1607979714918209, 0.0276438810333863, 0.0038405729373609, 0.0003951896511919, 0.0000321767881768, 0.0000002888167364, 0.0000003960315187 };

        public static double NormalDistICDF(double p)
        {
            //Inverse function of cumulative distribution function of standard normal distribution
            if (p >= 0.5 && p <= 0.92)
            {
                double num = 0.0, denom = 1.0;
                for (int i = 0; i < 4; i++)
                {
                    num += NormDistICDF_a[i] * Math.Pow((p - 0.5), 2 * i + 1);
                    denom += NormDistICDF_b[i] * Math.Pow((p - 0.5), 2 * i);
                }
                return num / denom;
            }
            else if (p > 0.92 && p < 1)
            {
                double num = 0.0;
                for (int i = 0; i < 9; i++)
                    num += NormDistICDF_c[i] * Math.Pow((Math.Log(-Math.Log(1 - p))), i);
                return num;
            }
            else
                return -1.0 * NormalDistICDF(1 - p);
        }

        public static double NormalDistICDF(double p, double mu, double sigma)
        {
            //Inverse function of cumulative distribution function of standard normal distribution
            return NormalDistICDF(p) * sigma + mu;
        }

        public static double[] GAMMA_P = new double[] { 0.99999999999980993, 676.5203681218851, -1259.1392167224028, 771.32342877765313, -176.61502916214059, 12.507343278686905, -0.13857109526572012, 9.9843695780195716e-6, 1.5056327351493116e-7 };

        public static double[] GAMMA_P2 = new double[] { 1.000000000190015, 76.18009172947146, -86.50532032941677, 24.01409824083091, -1.231739572450155, 0.0012086509738662, -0.000005395239385 };

        public static double Gamma(double x)
        {
            // Gamma function
            int g = 7;
            if (x < 0.5) return Math.PI / (Math.Sin(Math.PI * x) * Gamma(1 - x));
            x -= 1;
            double a = GAMMA_P[0], t = x + g + 0.5;
            for (int i = 1; i < 9; ++i)
                a += GAMMA_P[i] / (x + i);
            return 2.5066282746310005 * Math.Pow(t, x + 0.5) * Math.Exp(-t) * a;
        }

        public static double GammaLn(double x)
        {
            // Natual logarithm of Gamma function
            if (x < 3.72008E-44) return GammaLn(3.72008E-44);
            double y = x, ser = GAMMA_P2[0];
            for (int i = 1; i < 7; ++i)
                ser += (GAMMA_P2[i] / ++y);
            return Math.Log(2.5066282746310005 * ser / x) - (x + 5.5 - (x + 0.5) * Math.Log(x + 5.5));
        }

        private static double IncompleteGamma(double a, double x)
        {
            // Incomplete Gamma function
            int n;
            double p, q, d, s, s1, p0, q0, p1, q1, qln;
            if (a <= 0.0 || x < 0.0)
                return -1;

            if (x + 1.0 == 1.0) return 0;
            if (x > 1.0e+35) return 1;
            qln = q = a * Math.Log(x);
            if (x < 1.0 + a)
            {
                p = a;
                d = 1.0 / a;
                s = d;
                for (n = 1; n <= 100; n++)
                {
                    p = 1.0 + p;
                    d = d * x / p;
                    s = s + d;
                    if (Math.Abs(d) < Math.Abs(s) * 1.0e-07)
                    {
                        //s *= Math.Exp(-x) * qq / Gamma(a);
                        s *= Math.Exp(-x + qln - GammaLn(a));
                        return s;
                    }
                }
            }
            else
            {
                s = 1.0 / x;
                p0 = 0.0;
                p1 = 1.0;
                q0 = 1.0;
                q1 = x;
                for (n = 1; n <= 100; n++)
                {
                    p0 = p1 + (n - a) * p0;
                    q0 = q1 + (n - a) * q0;
                    p = x * p0 + n * p1;
                    q = x * q0 + n * q1;
                    if (Math.Abs(q) + 1.0 != 1.0)
                    {
                        s1 = p / q;
                        p1 = p;
                        q1 = q;
                        if (Math.Abs((s1 - s) / s1) < 1.0e-07)
                        {
                            //s = s1 * Math.Exp(-x) * qq / Gamma(a);
                            s = Math.Exp(Math.Log(s1) - x + qln - GammaLn(a));
                            return 1.0 - s;
                        }
                        s = s1;
                    }
                    p1 = p;
                    q1 = q;
                }
            }
            //s = 1.0 - s * Math.Exp(-x) * qq / Gamma(a);
            s = 1.0 - Math.Exp(Math.Log(s) - x + qln - GammaLn(a));
            return s;
        }

        private static double IncompleteGammaLn(double a, double x)
        {
            // Natual logarithm of incomplete Gamma function
            int n;
            double p, q, d, s, s1, p0, q0, p1, q1, qq;
            if (a <= 0.0 || x < 0.0)
                return -1;

            if (x + 1.0 == 1.0) return 0;
            if (x > 1.0e+35) return 1;
            q = a * Math.Log(x);
            qq = Math.Exp(q);
            if (x < 1.0 + a)
            {
                p = a;
                d = 1.0 / a;
                s = d;
                for (n = 1; n <= 100; n++)
                {
                    p = 1.0 + p;
                    d = d * x / p;
                    s = s + d;
                    if (Math.Abs(d) < Math.Abs(s) * 1.0e-07)
                    {
                        s = s * Math.Exp(-x) * qq / Gamma(a);
                        return s;
                    }
                }
            }
            else
            {
                s = 1.0 / x;
                p0 = 0.0;
                p1 = 1.0;
                q0 = 1.0;
                q1 = x;
                for (n = 1; n <= 100; n++)
                {
                    p0 = p1 + (n - a) * p0;
                    q0 = q1 + (n - a) * q0;
                    p = x * p0 + n * p1;
                    q = x * q0 + n * q1;
                    if (Math.Abs(q) + 1.0 != 1.0)
                    {
                        s1 = p / q;
                        p1 = p;
                        q1 = q;
                        if (Math.Abs((s1 - s) / s1) < 1.0e-07)
                        {
                            s = s1 * Math.Exp(-x) * qq / Gamma(a);
                            return 1.0 - s;
                        }
                        s = s1;
                    }
                    p1 = p;
                    q1 = q;
                }
            }
            s = 1.0 - s * Math.Exp(-x) * qq / Gamma(a);
            return s;
        }

        public static double GetRandNorm(Random rnd, double mean = 0, double std = 1)
        {
            // Generate a normally distributed random number
            double U1 = Math.Sqrt(-2 * Math.Log(rnd.NextDouble()));
            double U2 = 2 * Math.PI * rnd.NextDouble();
            return mean + std * U1 * Math.Cos(U2);
        }

        public static int GetRandCategorical(Random rnd, double[,] prob, int s, int K)
        {
            // Generate a categorical distributed random number
            double t = rnd.NextDouble();
            for (int i = 0; i < K; ++i)
            {
                if (t < prob[s, i]) return i;
                t -= prob[s, i];
            }
            return K - 1;
        }

        public static int GetRandCategorical(Random rnd, double[] prob, int K)
        {
            // Generate a categorical distributed random number
            double t = rnd.NextDouble() * prob.Sum();
            for (int i = 0; i < K; ++i)
            {
                if (t < prob[i]) return i;
                t -= prob[i];
            }
            return K - 1;
        }

        public static double GetRandGamma(Random rnd, double alpha, double beta = 1)
        {
            // Generate a Gamma distributed random number
            if (alpha < 1) return GetRandGamma(rnd, 1.0 + alpha, beta) * Math.Pow(rnd.NextDouble(), 1.0 / alpha);
            double x, v, u;
            double d = alpha - 1.0 / 3.0;
            double c = (1.0 / 3.0) / Math.Sqrt(d);

            while (true)
            {
                do
                {
                    x = GetRandNorm(rnd);
                    v = 1.0 + c * x;
                }
                while (v <= 0);

                v = v * v * v;
                u = rnd.NextDouble();

                if (u < 1 - 0.0331 * x * x * x * x) break;
                if (Math.Log(u) < 0.5 * x * x + d * (1 - v + Math.Log(v))) break;
            }
            return beta * d * v;
        }

        public static double GetRandBeta(Random rnd, double a, double b)
        {
            // Generate a Beta distributed random number
            double x = GetRandGamma(rnd, a);
            return x / (x + GetRandGamma(rnd, b));
        }

        public static double BetaDistLnPDF(double x, double a, double b)
        {
            // Natural logarithm of probability density function of Beta distribution
            x = Math.Max(x, MINALLELEFREQ); x = Math.Min(x, 1 - MINALLELEFREQ);
            return (GammaLn(a + b) - GammaLn(a) - GammaLn(b)) + (a - 1) * Math.Log(x) + (b - 1) * Math.Log(1 - x);
        }

        public static void GetRandDirichlet(Random rnd, double[,] a, int ai, double[,] b, int bi, double[,] c, int ci, int st, int n)
        {
            // Generate a Dirichlet distributed vector
            double sum = 0;
            n = Math.Min(a.GetLength(1), n + st);
            for (int i = st; i < n; ++i)
            {
                a[ai, i] = GetRandGamma(rnd, b[bi, i] + c[ci, i]);
                sum += a[ai, i];
            }
            for (int i = st; i < n; ++i)
                a[ai, i] /= sum;
        }

        public static void GetRandDirichlet(Random rnd, double[,] a, int ai, double[] b, double[,] c, int ci, int st, int n)
        {
            // Generate a Dirichlet distributed vector
            double sum = 0;
            n = Math.Min(a.GetLength(1), n + st);
            for (int i = st; i < n; ++i)
            {
                a[ai, i] = GetRandGamma(rnd, b[i] + c[ci, i]);
                sum += a[ai, i];
            }
            for (int i = st; i < n; ++i)
                a[ai, i] /= sum;
        }

        public static void GetRandDirichlet(Random rnd, double[] a, double[,] b, int bi, int st, int n)
        {
            // Generate a Dirichlet distributed vector
            double sum = 0;
            n = Math.Min(a.Length, n + st);
            for (int i = st; i < n; ++i)
            {
                a[i] = GetRandGamma(rnd, b[bi, i]);
                sum += a[i];
            }
            for (int i = st; i < n; ++i)
                a[i] /= sum;
        }

        public static void GetRandDirichlet(Random rnd, double[] a, double[] b, int st, int n)
        {
            //Generate a Dirichlet distributed vector
            double sum = 0;
            n = Math.Min(a.Length, n + st);
            for (int i = st; i < n; ++i)
            {
                a[i] = GetRandGamma(rnd, b[i]);
                sum += a[i];
            }
            for (int i = st; i < n; ++i)
                a[i] /= sum;
        }

        public static int GetRandCategoricalLnWrite(Random rnd, FastLog[] flog)
        {
            // Generate a categorical distributed random number, will overwrite flog
            double maxval = flog.Max(f => f.v1);
            int n = flog.Length;
            double sum = DUNDERFLOW;
            for (int i = 0; i < n; ++i)
            {
                flog[i].vlinear = MyExp(flog[i].v1 - maxval);
                sum += flog[i].vlinear;
            }

            double r = rnd.NextDouble() * sum;
            for (int i = 0; i < n; ++i)
            {
                if (r < flog[i].vlinear) return i;
                r -= flog[i].vlinear;
            }
            return n - 1;
        }

        private static double ChiSquareDistCDF(double x2, double df)
        {
            // Cumulative distribution function of Chi-Square distibution
            if (df == 0) return double.NaN;
            if (x2 < 0.0) x2 = -x2;
            return IncompleteGamma(df / 2.0, x2 / 2.0);
        }

        private static double[] BrokenStick(Random rnd, int k)
        {
            // Generate broken stick random vectors, equivalent to Dirichlet distribution D(1,1,...,1)
            List<double> a = new List<double>();
            a.Add(0);
            a.Add(1);
            for (int i = 0; i < k - 1; ++i)
                a.Add(rnd.NextDouble());
            a.Sort();

            double[] re = new double[k];
            for (int i = 0; i < k; ++i)
                re[i] = a[i + 1] - a[i];

            return re;
        }

        public static double FindMinIndex(double[] exp, ref int i1, ref int i2, double threshold)
        {
            // Find index of the minimum element
            int m = exp.Length, nle = 0;
            double minval1 = 1e300, minval2 = 1e300;
            i1 = i2 = -1;
            for (int i = 0; i < m; ++i)
            {
                if (exp[i] < threshold)
                    nle++;
                if (exp[i] < minval1)
                {
                    minval2 = minval1;
                    i2 = i1;

                    minval1 = exp[i];
                    i1 = i;
                }
                else if (exp[i] < minval2)
                {
                    minval2 = exp[i];
                    i2 = i;
                }
            }

            return nle / (double)m;
        }

        public static double FindMinIndex(double[,] exp, ref int i1, ref int j1, ref int i2, ref int j2, double threshold)
        {
            // Find index of the minimum element
            int m = exp.GetLength(0), n = exp.GetLength(1), nle = 0;
            double minval1 = 1e300, minval2 = 1e300;
            i1 = j1 = i2 = j2 = -1;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (exp[i, j] < threshold)
                        nle++;
                    if (exp[i, j] < minval1)
                    {
                        minval2 = minval1;
                        i2 = i1;
                        j2 = j1;

                        minval1 = exp[i, j];
                        i1 = i;
                        j1 = j;
                    }
                    else if (exp[i, j] < minval2)
                    {
                        minval2 = exp[i, j];
                        i2 = i;
                        j2 = j;
                    }
                }
            }
            return nle / (double)(m * n);
        }

        public static int CompareRow(double[,] obs, int n, int r1, int r2)
        {
            // Compare values in two rows
            for (int j = 0; j < n; ++j)
                if (obs[r1, j] > obs[r2, j]) return 1;
                else if (obs[r1, j] < obs[r2, j]) return -1;
            return 0;
        }

        public static int CompareCol(double[,] obs, int m, int c1, int c2)
        {
            // Compare values in two columns
            for (int i = 0; i < m; ++i)
                if (obs[i, c1] > obs[i, c2]) return 1;
                else if (obs[i, c1] < obs[i, c2]) return -1;
            return 0;
        }

        public static void SortCol(double[,] obs)
        {
            // Sort columns in an 2D array
            int m = obs.GetLength(0), n = obs.GetLength(1);
            for (int i = 0; i < n; ++i)
                for (int j = i + 1; j < n; ++j)
                    if (CompareCol(obs, m, i, j) > 0)
                        for (int k = 0; k < m; ++k)
                        {
                            double t = obs[k, i];
                            obs[k, i] = obs[k, j];
                            obs[k, j] = t;
                        }
        }

        public static void SortTable(double[] obs, double[] exp)
        {
            // Sort observed and expected tables by observed occurence
            int m = obs.Length;
            for (int i = 0; i < m; ++i)
                for (int j = i + 1; j < m; ++j)
                    if (obs[i] > obs[j])
                    {
                        double t = obs[i];
                        obs[i] = obs[j];
                        obs[j] = t;
                        t = exp[i];
                        exp[i] = exp[j];
                        exp[j] = t;
                    }
        }

        public static void CombineTable(double[,] obs, double[,] exp, ref double df,
                                        ref double g, ref double p, ref double p2, bool perm, Random rnd,
                                        ref double se, ref int switches, int burnin, int batches, int iterations)
        {
            // Perform Chi-square test of independence for a contingency table
            df = g = p = p2 = se = switches = burnin = 0;
            if (exp == null)
            {
                SortCol(obs);
                int m = obs.GetLength(0), n = obs.GetLength(1);
                double[] rowsum = new double[m], colsum = new double[n];
                exp = new double[m, n];
                double tot = 0;
                for (int i = 0; i < m; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        rowsum[i] += obs[i, j];
                        colsum[j] += obs[i, j];
                        tot += obs[i, j];
                    }
                }

                tot = 1.0 / tot;
                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        exp[i, j] = rowsum[i] * colsum[j] * tot;
            }

            if (obs.GetLength(0) < 2 || obs.GetLength(1) < 2)
                df = 0;
            else while (true)
                {
                    int m = obs.GetLength(0), n = obs.GetLength(1);
                    double[] rowsum = new double[m], colsum = new double[n];
                    for (int i = 0; i < m; ++i)
                    {
                        for (int j = 0; j < n; ++j)
                        {
                            rowsum[i] += obs[i, j];
                            colsum[j] += obs[i, j];
                        }
                    }

                    int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
                    double rate = FindMinIndex(exp, ref i1, ref j1, ref i2, ref j2, 5.0);

                    if (exp[i1, j1] > 1.0 && rate < 0.2)
                    {
                        df = (m - 1) * (n - 1);
                        break;
                    }

                    if (m == 2 && n == 2)
                    {
                        df = 0;
                        break;
                    }

                    FindMinIndex(rowsum, ref i1, ref i2, 5.0);
                    FindMinIndex(colsum, ref j1, ref j2, 5.0);

                    int m1 = m, n1 = n;
                    if (m > 2 && n > 2)
                    {
                        if (m >= n)
                        {
                            m1--;
                            j1 = j2 = int.MaxValue;
                        }
                        else
                        {
                            n1--;
                            i1 = i2 = int.MaxValue;
                        }
                    }
                    else if (m > 2)
                    {
                        m1--;
                        j1 = j2 = int.MaxValue;
                    }
                    else if (n > 2)
                    {
                        n1--;
                        i1 = i2 = int.MaxValue;
                    }

                    double[,] obs2 = new double[m1, n1], exp2 = new double[m1, n1];
                    for (int i = 0; i < m; ++i)
                    {
                        int r = i == i1 ? i2 : i;
                        r = r > i1 ? r - 1 : r;
                        for (int j = 0; j < n; ++j)
                        {
                            int c = j == j1 ? j2 : j;
                            c = c > j1 ? c - 1 : c;
                            obs2[r, c] += obs[i, j];
                            exp2[r, c] += exp[i, j];
                        }
                    }
                    obs = obs2;
                    exp = exp2;
                }

            if (df > 0)
            {
                int m = obs.GetLength(0), n = obs.GetLength(1);
                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        if (obs[i, j] > 0)
                            g += 2 * obs[i, j] * Math.Log(obs[i, j] / exp[i, j]);

                p = 1 - ChiSquareDistCDF(g, df);
                if (perm)
                    p2 = RaymondTest(rnd, obs, ref se, ref switches, burnin, batches, iterations);
            }
            else
            {
                p = double.NaN;
                if (perm)
                    p2 = double.NaN;
            }
        }

        public static void CombineTable(ref double[] obs, ref double[] exp, ref double df, ref double g, ref double p)
        {
            // Perform Chi-square goodness-of-fit test for a contingency table
            double so = obs.Sum(), se = exp.Sum();
            if (so > se)
            {
                SortTable(obs, exp);
                int m = exp.Length;
                double[] obs2 = new double[m + 1];
                double[] exp2 = new double[m + 1];
                Array.Copy(obs, obs2, m);
                Array.Copy(exp, exp2, m);
                exp2[m] = so - se;
                obs = obs2;
                exp = exp2;
            }

            if (exp.Length < 2)
                df = 0;
            else while (true)
            {
                int m = exp.Length;
                int i1 = 0, i2 = 0;
                double rate = FindMinIndex(exp, ref i1, ref i2, 5.0);

                if (exp[i1] > 1.0 && rate == 0)
                {
                    df = m - 1;
                    break;
                }

                if (m == 2)
                {
                    df = 0;
                    break;
                }

                int m1 = m;
                if (m > 2) m1--;

                double[] exp2 = new double[m1], obs2 = new double[m1];
                for (int i = 0; i < m; ++i)
                {
                    int r = (m1 != m && i == i1) ? i2 : i;
                    r = (m1 != m && r > i1) ? r - 1 : r;
                    exp2[r] += exp[i];
                    obs2[r] += obs[i];
                }
                exp = exp2;
                obs = obs2;
            }

            if (df > 0)
            {
                int m = obs.GetLength(0);
                for (int i = 0; i < m; ++i)
                    if (obs[i] > 0)
                        g += 2 * obs[i] * Math.Log(obs[i] / exp[i]);

                p = 1 - ChiSquareDistCDF(g, df);
            }
            else
            {
                g = p = double.NaN;
            }
        }

        public static double RaymondTest(Random rnd, double[,] mat, ref double SE, ref int switches, int burnin, int batch, int iter)
        {
            //Perform Raymond Test for a contingency table
            //Step 1
            switches = 0;
            SE = 0;
            double INF = 0, rho = 0;
            int m = mat.GetLength(0), n = mat.GetLength(1);
            if (m < 2 || n < 2) return double.NaN;

            //Step 6
            int Y = burnin + batch * iter, inf = 0;
            for (int y = 0; y < Y; ++y)
            {
                //Step 2
                int i1 = rnd.Next(m), j1 = rnd.Next(n);
                int i2 = NextAvoid(rnd, m, i1), j2 = NextAvoid(rnd, n, j1);

                //Step 3
                if (mat[i1, j1] < 1 || mat[i2, j2] < 1) goto step5;

                //Step 4
                double R = (mat[i1, j1] * mat[i2, j2]) / ((mat[i2, j1] + 1) * (mat[i1, j2] + 1));

                if (R >= 1 || rnd.NextDouble() < R)
                {
                    if (y > burnin) switches++;
                    rho += Math.Log(R);
                    //if (Math.Abs(rho) < 0.00000001) rho = 0;
                    mat[i1, j1]--; mat[i2, j2]--;
                    mat[i2, j1]++; mat[i1, j2]++;
                }

            //Step 5
            step5:
                if (rho <= 0 && y >= burnin)
                    inf++;

                //Step 6
                if (y > burnin && (y - burnin) % iter == iter - 1)
                {
                    double p = inf / (double)iter;
                    INF += p;
                    SE += p * p;
                    inf = 0;
                }
            }

            //Step 7
            INF /= batch; //ex
            SE /= batch; //ex2
            SE = Math.Sqrt((SE - INF * INF) / (batch - 1));
            return INF;
        }
        #endregion

        #region OPTIMIZATION

        public class Point4 : IComparable, IComparable<Point4>
        {
            //Downhill-Simplex algorithm

            public double[] image;
            public double[] real;
            public double li;
            public int dim;
            public bool confine;
            public int diff;

            public Point4(Point4 a)
            {
                image = Clone(a.image);
                real = Clone(a.real);
                diff = a.diff;
                dim = a.dim;
                confine = a.confine;
                li = a.li;
            }

            public Point4(int de)
            {
                image = new double[Math.Max(de, 8)];
                real = new double[Math.Max(de, 9)];
                diff = 0;
                dim = de;
                for (int i = 0; i < image.Length; ++i)
                    image[i] = 0;
            }

            public int CompareTo(Point4 b)
            {
                return li.CompareTo(b.li);
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                return CompareTo((Point4)obj);
            }

            public override bool Equals(object obj)
            {
                return obj is Point4 && li == ((Point4)obj).li;
            }

            public static bool operator ==(Point4 a, Point4 b)
            {
                return a.li == b.li;
            }

            public static bool operator !=(Point4 a, Point4 b)
            {
                return a.li != b.li;
            }

            public static bool operator >(Point4 a, Point4 b)
            {
                return a.li > b.li;
            }

            public static bool operator >=(Point4 a, Point4 b)
            {
                return a.li >= b.li;
            }

            public static bool operator <(Point4 a, Point4 b)
            {
                return a.li < b.li;
            }

            public static bool operator <=(Point4 a, Point4 b)
            {
                return a.li <= b.li;
            }

            public static Point4 operator +(Point4 a, Point4 b)
            {
                Point4 t = new Point4(a);
                for (int i = 0; i < 8; ++i)
                    t.image[i] = a.image[i] + b.image[i];
                t.li = 0;
                return t;
            }

            public static Point4 operator -(Point4 a, Point4 b)
            {
                Point4 t = new Point4(a);
                for (int i = 0; i < 8; ++i)
                    t.image[i] = a.image[i] - b.image[i];
                t.li = 0;
                return t;
            }

            public static Point4 operator *(Point4 a, double b)
            {
                Point4 t = new Point4(a);
                for (int i = 0; i < 8; ++i)
                    t.image[i] = a.image[i] * b;
                t.li = 0;
                return t;
            }

            public static Point4 operator /(Point4 a, double b)
            {
                Point4 t = new Point4(a);
                for (int i = 0; i < 8; ++i)
                    t.image[i] = a.image[i] / b;
                t.li = 0;
                return t;
            }

            double distancer(Point4 a)
            {
                double s = 0;
                for (int i = 0; i < dim; ++i)
                    s += (real[i] - a.real[i]) * (real[i] - a.real[i]);
                return Math.Sqrt(s);
            }

            public double distancem(Point4 a)
            {
                double s = 0;
                for (int i = 0; i < dim; ++i)
                    s += (image[i] - a.image[i]) * (image[i] - a.image[i]);
                return Math.Sqrt(s);
            }

            public void i2r()
            {
                if (diff == 0 && dim % 2 == 0)
                {
                    if (dim == 1)
                    {
                        real[0] = 1 / (1 + Math.Exp(-image[0]));
                        real[1] = 1 - real[0];
                    }
                    else if (dim == 2)
                    {
                        double p1 = 1 / (1 + Math.Exp(-image[0]));
                        double q1 = 1 / (1 + Math.Exp(-image[1]));
                        double p0 = 1 - p1;
                        double q0 = 1 - q1;
                        real[0] = p1 * q1;
                        real[1] = p0 * q1 + p1 * q0;
                        real[2] = p0 * q0;
                    }
                    else if (dim == 4)
                    {
                        double p2 = 1 / (1 + Math.Exp(-image[0]));
                        double p1 = (1 - p2) / (1 + Math.Exp(-image[1]));
                        double q2 = 1 / (1 + Math.Exp(-image[2]));
                        double q1 = (1 - q2) / (1 + Math.Exp(-image[3]));
                        double p0 = 1 - p2 - p1;
                        double q0 = 1 - q2 - q1;
                        real[0] = p2 * q2;
                        real[1] = p2 * q1 + p1 * q2;
                        real[2] = p2 * q0 + p0 * q2 + p1 * q1;
                        real[3] = p0 * q1 + p1 * q0;
                        real[4] = p0 * q0;
                    }
                    else if (dim == 6)
                    {
                        double p3 = 1 / (1 + Math.Exp(-image[0]));
                        double p2 = (1 - p3) / (1 + Math.Exp(-image[1]));
                        double p1 = (1 - p3 - p2) / (1 + Math.Exp(-image[2]));
                        double q3 = 1 / (1 + Math.Exp(-image[3]));
                        double q2 = (1 - q3) / (1 + Math.Exp(-image[4]));
                        double q1 = (1 - q3 - q2) / (1 + Math.Exp(-image[5]));
                        double p0 = 1 - p3 - p2 - p1;
                        double q0 = 1 - q3 - q2 - q1;
                        real[0] = p3 * q3;
                        real[1] = p3 * q2 + p2 * q3;
                        real[2] = p3 * q1 + p2 * q2 * p1 * q3;
                        real[3] = p3 * q0 + p2 * q1 + p1 * q2 + p0 * q3;
                        real[4] = p2 * q0 + p1 * q1 + p0 * q2;
                        real[5] = p1 * q0 + p0 * q1;
                        real[6] = p0 * q0;
                    }
                    else if (dim == 8)
                    {
                        double p4 = 1 / (1 + Math.Exp(-image[0]));
                        double p3 = (1 - p4) / (1 + Math.Exp(-image[1]));
                        double p2 = (1 - p4 - p3) / (1 + Math.Exp(-image[2]));
                        double p1 = (1 - p4 - p3 - p2) / (1 + Math.Exp(-image[3]));
                        double q4 = 1 / (1 + Math.Exp(-image[4]));
                        double q3 = (1 - q4) / (1 + Math.Exp(-image[5]));
                        double q2 = (1 - q4 - q3) / (1 + Math.Exp(-image[6]));
                        double q1 = (1 - q4 - q3 - q2) / (1 + Math.Exp(-image[7]));
                        double p0 = 1 - p4 - p3 - p2 - p1;
                        double q0 = 1 - q4 - q3 - q2 - q1;
                        real[0] = p4 * q4;
                        real[1] = p4 * q3 + p3 * q4;
                        real[2] = p4 * q2 + p3 * q3 * p2 * q4;
                        real[3] = p4 * q1 + p3 * q2 + p2 * q3 + p1 * q4;
                        real[4] = p4 * q0 + p3 * q1 + p2 * q2 + p1 * q3 + p0 * q4;
                        real[5] = p3 * q0 + p2 * q1 + p1 * q2 + p0 * q3;
                        real[6] = p2 * q0 + p1 * q1 + p0 * q2;
                        real[7] = p1 * q0 + p0 * q1;
                        real[8] = p0 * q0;
                    }
                }
                else
                {
                    real[dim] = 1;
                    for (int i = 0; i < dim; ++i)
                    {
                        real[i] = real[dim] / (1 + Math.Exp(-image[i]));
                        real[dim] -= real[i];
                    }
                }
            }

            public double i2r_selfing()
            {
                real[0] = 1.0 / (1 + Math.Exp(image[0]));
                //real = Math.Exp(image);
                if (real[0] < MINALLELEFREQ) real[0] = MINALLELEFREQ;
                if (real[0] > 1 - MINALLELEFREQ) real[0] = 1 - MINALLELEFREQ;
                return real[0];
            }

            public void r2i_selfing()
            {
                image[0] = -Math.Log(1 / real[0] - 1);
                //image = Math.Log(real);
            }

            public static bool isbreak(Point4[] xp, double eps = 0)
            {
                return xp[0].distancer(xp[xp.Length - 1]) < eps;
            }

            public static void order(Point4[] xp)
            {
                /*
                Point4 t;
                for (int i = 0; i < xp.Length; ++i)
                    for (int j = i + 1; j < xp.Length; ++j)
                        if (xp[i] < xp[j])
                        {
                            t = xp[i];
                            xp[i] = xp[j];
                            xp[j] = t;
                        }
                */
                Array.Sort(xp, (x, y) => y.CompareTo(x));
            }

            public static Point4 DownHillSimplex(int dim, int rep, Action<Point4, object[]> f_likelihood, object[] par, Action<Point4> f_init = null)
            {
                // Down-hill Simplex Algorithm

                Point4[] xp = new Point4[dim + 1];
                for (int i = 0; i <= dim; ++i)
                {
                    xp[i] = new Point4(dim);
                    if (f_init != null) f_init.Invoke(xp[i]);
                    if (i > 0) xp[i].image[i - 1] = 0.1;
                    f_likelihood(xp[i], par);
                }

                double sep = 0.1;
                double likestop = LIKESTOP1;
                for (int kk = 0; kk < rep; ++kk)
                {
                    //downhill simplex method
                    for (int searchcount = 0; searchcount < MAX_ITER_ML; ++searchcount)
                    {
                        //Order
                        Point4.order(xp);
                        if (Point4.isbreak(xp, LIKESTOP1) && Math.Abs(xp[0].real[0] - xp[1].real[0]) < LIKESTOP2) break;

                        //Reflect
                        Point4 x0 = xp[0];
                        for (int i = 1; i < dim; ++i)
                            x0 += xp[i];
                        x0 /= dim;
                        Point4 xr = x0 + (x0 - xp[dim]);
                        f_likelihood(xr, par);

                        //Expansion
                        //best
                        if (xr > xp[0])
                        {
                            //Point4 xe = x0 + (x0 - xp[dim]) * 2;
                            Point4 xe = x0 + (xr - x0) * 2;
                            f_likelihood(xe, par);
                            xp[1] = xp[0];
                            Array.Copy(xp, 0, xp, 1, dim);
                            xp[0] = xe > xr ? xe : xr;
                            continue;
                        }

                        //better than second worst
                        if (xr > xp[dim - 1])
                        {
                            xp[dim] = xr;
                            continue;
                        }

                        //worse than second worst
                        //Contraction
                        //Point4 xc = xp[dim] + (x0 - xp[dim]) * 0.5;
                        Point4 xc = x0 + (xp[dim] - x0) * 0.5;
                        f_likelihood(xc, par);
                        if (xc > xp[dim])
                        {
                            xp[dim] = xc;
                            continue;
                        }

                        //Reduction
                        for (int i = 1; i <= dim; ++i)
                        {
                            xp[i] =  (xp[i] + xp[0]) * 0.5;
                            f_likelihood(xp[i], par);
                        }
                    }

                    if (kk == rep - 1) break;

                    for (int i = 1; i <= dim; ++i)
                    {
                        xp[i] = new Point4(xp[0]);
                        xp[i].image[i - 1] *= (1 - sep);
                        f_likelihood(xp[i], par);
                    }

                    sep /= 2;
                    likestop /= 2;
                }

                return xp[0];
            }
        };
        #endregion

        #region TREE
        public struct DendrogramBranch
        {
            public double len;
            public double x;
            public double y;
            public DendrogramBranch[] sub;
            public string name;
        };
        public static int CLUSTERING_CX = 0, CLUSTERING_CY = 0;

        public static Image DrawClustering(ref byte[] VecFile, string at1, int fontsize = 12, int left = 10, int right = 40, int linesep = 8, int picwidth = 640, int maxheight = 640, int header = 30, int footer = 20, bool bold = false, bool italic = false, bool subname = false)
        {
            if (at1.LastIndexOf(")") == -1)
                return null;
            at1 = at1.Substring(0, at1.LastIndexOf(")")) + ");";
            string[] a = at1.Replace("\r", "").Replace("\n", "").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //analysis
            int picheight = 0;
            int subfig = 0;
            foreach (string b in a)
            {
                if (b.Contains("("))
                {
                    // is a tree
                    int nspecies = b.Count(c => c == ',') + 1;
                    if (nspecies > 0)
                    {
                        picheight += header + footer + nspecies * (fontsize + linesep);
                        subfig++;
                    }
                }
            }
            picheight += header + footer;
            Bitmap bmp = new Bitmap(picwidth, picheight);
            MemoryStream ms = null; Graphics gdc = null; Metafile mf = null; Graphics g = null;

            if (OS == OperationSystem.Windows)
            {
                //Vector image
                ms = new MemoryStream();
                gdc = Graphics.FromHwndInternal(IntPtr.Zero);
                mf = new Metafile(ms, gdc.GetHdc(), EmfType.EmfPlusOnly);
                gdc.ReleaseHdc();
                g = Graphics.FromImage(mf);
            }
            else
                g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            if (picheight == maxheight)
            {
                int cheight = header;
                int no = 1;
                foreach (string b in a)
                {
                    CLUSTERING_CX = 0;
                    if (b.Contains("("))
                    {
                        // is a tree
                        int nspecies = b.Count(c => c == ',') + 1;
                        if (nspecies > 0)
                        {
                            //count branchs
                            DendrogramBranch root = new DendrogramBranch();
                            root.len = 0;
                            root.x = 0;
                            root.y = 0;
                            root.name = "";
                            if (b.Substring(b.LastIndexOf(")") + 1, b.Length - b.LastIndexOf(")") - 1).Contains(':'))
                            {
                                root.len = double.Parse(b.Substring(b.LastIndexOf(":") + 1, b.Length - b.LastIndexOf(":") - 1));
                                root.name = b.Substring(b.LastIndexOf(")") + 1, b.LastIndexOf(":") - b.LastIndexOf(")") - 1);
                            }
                            CLUSTERING_CY = 0;
                            CLUSTERING_MAXX = 0;
                            root.sub = GetClusteringBranch(b, ref root);

                            //plot
                            if (CLUSTERING_MAXX == 0) return null;
                            PlotClustering(no++, nspecies, cheight, root, g, fontsize, left, (int)(right + CLUSTERING_CX * fontsize * 2.2 / 3), linesep, picwidth, header, footer, bold, italic, subname);
                            cheight += header + footer + nspecies * (fontsize + linesep);
                        }
                    }
                }
            }

            if (OS == OperationSystem.Windows)
            {
                //write VecFile
                g.Dispose();
                ms.Seek(0, SeekOrigin.Begin);
                VecFile = new byte[ms.Length];
                ms.Read(VecFile, 0, (int)ms.Length);

                //draw bitmap
                g = Graphics.FromImage(bmp);
                g.DrawImage(mf, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                mf.Dispose();
                ms.Dispose();
            }
            else
                VecFile = new byte[0];

            MemoryStream m = new MemoryStream();
            bmp.Save(m, ImageFormat.Png);
            bmp.Dispose();
            return Image.FromStream(m);
        }

        public static double CLUSTERING_CURRENTY;
        public static double CLUSTERING_MAXX;
        private static void PlotClustering(int n, int nspecies, int cheight, DendrogramBranch root, Graphics tg, int fontsize, int left, int right, int linesep, int picwidth, int header, int footer, bool bold, bool italic, bool subname)
        {
            //plot header
            //tg.DrawString("(" + n + ") " + nspecies + " species, " + DateTime.Now.ToString(), new Font("Arial", fontsize), new SolidBrush(Color.Black), margin, margin + cheight);
            Pen a = new Pen(new SolidBrush(Color.Black), 2);
            //scale
            double scaleX = (picwidth - left - right) / CLUSTERING_MAXX; //1 = n pixel
            double scaleY = fontsize + linesep; //1 = n pixel
            FontStyle fs = FontStyle.Regular;
            if (bold)
                fs |= FontStyle.Bold;
            if (italic)
                fs |= FontStyle.Italic;
            PlotClusteringBranch(root, a, tg, scaleX, scaleY, left, cheight + header, fontsize, fs, subname);

            double scale = 1;
            double scaleX2 = scaleX;
            while (scaleX2 >= 200)
            {
                scaleX2 /= 10;
                scale /= 10;
            }
            while (scaleX2 < 20)
            {
                scaleX2 *= 10;
                scale *= 10;
            }
            tg.DrawLine(a, new PointF((float)(left), (float)(header)),
                        new PointF((float)(left + scaleX * scale), (float)(header)));
            StringFormat stf = new StringFormat();
            stf.Alignment = StringAlignment.Center;
            stf.LineAlignment = StringAlignment.Near;
            tg.DrawString(scale.ToString(),
                new Font("Arial", fontsize / DPI_SCALE),
                new SolidBrush(Color.Black),
                new RectangleF(
                (float)(left - 500 + scaleX * scale / 2), (float)(header) + 2,
                (float)(1000), (float)100),
                stf);

        }

        private static void PlotClusteringBranch(DendrogramBranch root, Pen p, Graphics tg, double scaleX, double scaleY, float zx, float zy, int fontsize, FontStyle fs, bool subname)
        {
            if (root.sub.Length > 1)
                tg.DrawLine(p, new PointF((float)(zx + scaleX * (root.x + root.len)), (float)(zy + root.sub[0].y * scaleY)),
                            new PointF((float)(zx + scaleX * (root.x + root.len)), (float)(zy + root.sub[root.sub.Length - 1].y * scaleY)));

            //if (root.len > 0)
            tg.DrawLine(p, new PointF((float)(zx + scaleX * (root.x + root.len)), (float)(zy + root.y * scaleY)),
                        new PointF((float)(zx + scaleX * root.x), (float)(zy + root.y * scaleY)));

            StringFormat stf = new StringFormat();
            stf.Alignment = StringAlignment.Near;
            stf.LineAlignment = StringAlignment.Center;

            if (subname || root.sub.Length == 0)
                tg.DrawString(root.name, new Font("Arial", fontsize / DPI_SCALE, fs), new SolidBrush(Color.Black), new RectangleF((float)(zx + 5 + scaleX * (root.x + root.len)), (float)(zy + root.y * scaleY) - 20, 140, 40), stf);
            foreach (DendrogramBranch a in root.sub)
                PlotClusteringBranch(a, p, tg, scaleX, scaleY, zx, zy, fontsize, fs, subname);
        }

        private static DendrogramBranch[] GetClusteringBranch(string a, ref DendrogramBranch parent)
        {
            //count subs
            int lay = 0;
            int n = 1;
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == '(')
                    lay++;
                else if (a[i] == ')')
                    lay--;
                if (lay == 1 && a[i] == ',')
                    n++;
            }
            DendrogramBranch[] re = new DendrogramBranch[n];
            int c = 0;
            int last = 0;
            int last2 = 0;
            bool bo = true;
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == '(' && bo)
                {
                    bo = false;
                    last = i + 1;
                }

                if (lay == 1)
                {
                    if (a[i] == ':')
                        last2 = i + 1;
                    if (a[i] == ',' || a[i] == ')')
                    {
                        // a sub DendrogramBranch identifier
                        re[c].x = parent.x + parent.len;
                        re[c].y = 0;
                        re[c].len = double.Parse(a.Substring(last2, i - last2));
                        if (CLUSTERING_MAXX < re[c].x + re[c].len)
                            CLUSTERING_MAXX = re[c].x + re[c].len;
                        int at = 1 + Math.Max(Math.Max(a.LastIndexOf(',', last2), a.LastIndexOf(')', last2)), a.LastIndexOf('(', last2));
                        re[c].name = a.Substring(at, last2 - at - 1);

                        if (re[c].name.Length > CLUSTERING_CX)
                        {
                            CLUSTERING_CX = re[c].name.Length;
                        }
                        if (a[at - 1] == ')')
                            re[c].sub = GetClusteringBranch(a.Substring(last, i - last - 1), ref re[c]);
                        else
                        {
                            re[c].sub = new DendrogramBranch[0];
                            re[c].y = CLUSTERING_CY++;
                        }
                        c++;
                        last = i + 1;
                    }
                }
                if (a[i] == '(')
                    lay++;
                else if (a[i] == ')')
                    lay--;
            }
            parent.y = 0;
            foreach (DendrogramBranch aa in re)
                parent.y += aa.y;
            parent.y /= re.Length;
            return re;
        }

        #endregion

        #region HASH

        public static uint[] CRYPT_TABLE = null;

        public static void PrepareCryptTable()
        {
            // Prepare crypt table for hash function
            CRYPT_TABLE = new uint[0x500];
            uint dwHih, dwLow, seed = 0x00100001, index1 = 0, index2 = 0, i;
            for (index1 = 0; index1 < 0x100; index1++)
            {
                for (index2 = index1, i = 0; i < 5; i++, index2 += 0x100)
                {
                    seed = (seed * 125 + 3) % 0x2AAAAB;
                    dwHih = (seed & 0xFFFF) << 0x10;
                    seed = (seed * 125 + 3) % 0x2AAAAB;
                    dwLow = (seed & 0xFFFF);
                    CRYPT_TABLE[index2] = (dwHih | dwLow);
                }
            }
        }

        public static uint HashString(string str, int type = 0x200)
        {
            // Return the hash value of a string
            uint dwSeed1 = 0x7FED7FED, dwSeed2 = 0xEEEEEEEE;
            uint b1, b2;
            for (int i = 0; i < str.Length; ++i)
            {
                b1 = (uint)str[i] >> 8;
                b2 = (uint)str[i] & 0xFF;
                dwSeed1 = CRYPT_TABLE[type + b1] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b1 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                dwSeed1 = CRYPT_TABLE[type + b2] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b2 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
            }
            return dwSeed1;
        }

        public static uint HashPhenotype(int ploidy, IEnumerable<int> alleles, int type = 0x200)
        {
            // Return the hash value of a phenotype
            int len = 0;
            uint dwSeed1 = 0x7FED7FED, dwSeed2 = 0xEEEEEEEE;
            uint b1, b2;
            {
                uint t = (uint)ploidy;
                b1 = t & 0xFF; t >>= 8;
                b2 = t & 0xFF;
                dwSeed1 = CRYPT_TABLE[type + b1] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b1 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                dwSeed1 = CRYPT_TABLE[type + b2] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b2 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
            }
            foreach (int a in alleles)
            {
                uint t = (uint)a;
                b1 = t & 0xFF; t >>= 8;
                b2 = t & 0xFF;
                dwSeed1 = CRYPT_TABLE[type + b1] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b1 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                dwSeed1 = CRYPT_TABLE[type + b2] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b2 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                len++;
            }
            return len == 0 ? 0 : dwSeed1;
        }

        public static uint HashGenotype(IEnumerable<int> alleles, int type = 0x200)
        {
            // Return the hash value of a genotype
            int len = 0;
            uint dwSeed1 = 0x7FED7FED, dwSeed2 = 0xEEEEEEEE;
            uint b1, b2;
            foreach (int a in alleles)
            {
                uint t = (uint)a;
                b1 = t & 0xFF; t >>= 8;
                b2 = t & 0xFF;
                dwSeed1 = CRYPT_TABLE[type + b1] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b1 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                dwSeed1 = CRYPT_TABLE[type + b2] ^ (dwSeed1 + dwSeed2);
                dwSeed2 = b2 + dwSeed1 + dwSeed2 + (dwSeed2 << 5) + 3;
                len++;
            }
            return len == 0 ? 0 : dwSeed1;
        }

        #endregion

        #region MANTEL
        // Mantel test: test the correlation between two matrices, with some other matrices controlled

        private double PartialCorr(double a, double b, double c)
        {
            // Calclate partial correlation
            return ((a - b * c) / Math.Sqrt((1 - b * b) * (1 - c * c)));
        }

        private void MantelPermute(object sender, EventArgs e)
        {
            // UI button process function

            if (runstate == GlobalRunState.running || runstate == GlobalRunState.mantelrunning || runstate == GlobalRunState.simulating || runstate == GlobalRunState.end) return;
            MANTEL_CPERM = 0;
            MANTEL_NSIG = 0;
            MantelResBox.Text = "";

            if (SEED_REFRESH)
            {
                GlobalSeedBox.Value = GLOBAL_RND.Next((int)(GlobalSeedBox.Maximum + 1)) % (int)(GlobalSeedBox.Maximum + 1);
                SEED = (int)GlobalSeedBox.Value;
            }

            ApplySettings();

            runstate = GlobalRunState.mantelrunning;
            if (THREAD != null) THREAD.Abort();
            THREAD = new Thread(new ThreadStart(MantelTest));
            MANTEL_INPUT = MantelMatBox.Text;
            THREAD.Start();
        }

        private void MantelTest()
        {
            // Prepare Mantel Test

            // Format matrix
            string[,] manteltext = manteltext = StringToMatrix(MANTEL_INPUT);
            List<double[,]> matrixdata = new List<double[,]>();
            List<string> matrixname = new List<string>();
            List<double[]> matrixstat = new List<double[]>();
            Dictionary<string, int> mantelseq = new Dictionary<string, int>();
            Dictionary<string, int> manteltseq = new Dictionary<string, int>();
            double[] mantelR = new double[3];

            if (manteltext == null)
            {
                runstate = GlobalRunState.mantelbreak;
                return;
            }
            int n = manteltext.GetLength(1) - 1;
            if (manteltext.GetLength(0) != (n + 1) * 2 && manteltext.GetLength(0) != (n + 1) * 3 && manteltext.GetLength(0) != (n + 1) * 4 && manteltext.GetLength(0) != (n + 1) * 5 && manteltext.GetLength(0) != (n + 1) * 6 && manteltext.GetLength(0) != (n + 1) * 7)
            {
                ShowErrorMessage("Error reading input matrices, the number of rows are not multiples of number of columns", "Error", 0);
                return;
            }
            for (int i = 0; i < n; ++i)
            {
                if (mantelseq.ContainsKey(manteltext[0, i + 1]))
                {
                    ShowErrorMessage("Error reading input matrices, repeated grid name found at row header.", "Error", 0);
                    runstate = GlobalRunState.mantelbreak;
                    return;
                }
                mantelseq[manteltext[0, i + 1]] = i;
            }

            int[] xseq = GetIdxSeq(n);

            // Check row and column header and matrix name
            string col = null, row = null, mname = null;
            for (int i = 0; i < manteltext.GetLength(0); i += n + 1)
            {
                if (matrixname.Contains(manteltext[i, 0]))
                {
                    ShowErrorMessage("Error reading input matrices, repeated matrix name found.", "Error", 0);
                    runstate = GlobalRunState.mantelbreak;
                    return;
                }
                matrixname.Add(manteltext[i, 0]);
                manteltseq.Clear();
                for (int j = 0; j < n; ++j)
                {
                    if (!mantelseq.ContainsKey(manteltext[i + j + 1, 0]))
                    {
                        ShowErrorMessage("Error reading input matrices, grid column header does not meet the first matrix.", "Error", 0);
                        runstate = GlobalRunState.mantelbreak;
                        return;
                    }

                    if (manteltseq.ContainsKey(manteltext[i + j + 1, 0]))
                    {
                        ShowErrorMessage("Error reading input matrices, repeated grid column header at matrix " + manteltext[i, 0] + ".", "Error", 0);
                        runstate = GlobalRunState.mantelbreak;
                        return;
                    }
                    manteltseq[manteltext[i + j + 1, 0]] = 0;
                }

                manteltseq.Clear();
                for (int j = 0; j < n; ++j)
                {
                    if (!mantelseq.ContainsKey(manteltext[i, j + 1]))
                    {
                        ShowErrorMessage("Error reading input matrices, grid row header does not meet the first matrix.", "Error", 0);
                        runstate = GlobalRunState.mantelbreak;
                        return;
                    }

                    if (manteltseq.ContainsKey(manteltext[i, j + 1]))
                    {
                        ShowErrorMessage("Error reading input matrices, repeated grid row header at matrix " + manteltext[i, 0] + ".", "Error", 0);
                        runstate = GlobalRunState.mantelbreak;
                        return;
                    }
                    manteltseq[manteltext[i + j + 1, 0]] = 0;
                }

                mname = manteltext[i, 0];
                double[,] tdata = new double[n, n];
                for (int i1 = 0; i1 < n; ++i1)
                {
                    row = manteltext[i + 1 + i1, 0];
                    for (int j1 = 0; j1 < n; ++j1)
                    {
                        try
                        {
                            col = manteltext[i, j1 + 1];
                            tdata[mantelseq[row], mantelseq[col]] = double.Parse(manteltext[i + 1 + i1, j1 + 1]);
                        }
                        catch
                        {
                            ShowErrorMessage("Error reading input matrices, at row " + row + " column " + col + " in matrix " + mname + ". Error parsing string to real number. ", "Error", 0);
                            runstate = GlobalRunState.mantelbreak;
                            return;
                        }
                    }
                }

                for (int i1 = 0; i1 < n; ++i1)
                {
                    row = manteltext[i + 1 + i1, 0];
                    if (tdata[i1, i1] != 0)
                    {
                        ShowErrorMessage("Error reading input matrices, at row " + row + " column " + row + " in matrix " + mname + ". Elements in the diagnoal line should be zero.", "Error", 0);
                        runstate = GlobalRunState.mantelbreak;
                        return;
                    }
                    for (int j1 = 0; j1 < i1; ++j1)
                    {
                        col = manteltext[i1, j1 + 1];
                        if (tdata[i1, j1] != tdata[j1, i1])
                        {
                            ShowErrorMessage("Error reading input matrices, at row " + row + " column " + row + " in matrix " + mname + ". Matrix should be symmetric.", "Error", 0);
                            runstate = GlobalRunState.mantelbreak;
                            return;
                        }
                    }
                }

                double[] tstat = new double[6];
                tstat[3] = 1e300; tstat[4] = -1e300;
                for (int i1 = 0; i1 < n; ++i1)
                {
                    for (int j1 = 0; j1 < i1; ++j1)
                    {
                        tstat[0] += tdata[i1, j1];
                        tstat[1] += tdata[i1, j1] * tdata[i1, j1];
                        tstat[3] = Math.Min(tdata[i1, j1], tstat[3]);
                        tstat[4] = Math.Max(tdata[i1, j1], tstat[4]);
                    }
                }
                tstat[0] /= n * (n - 1) / 2;
                tstat[1] /= n * (n - 1) / 2;
                tstat[2] = tstat[1] - tstat[0] * tstat[0];
                for (int i1 = 0; i1 < n; ++i1)
                    for (int j1 = 0; j1 < i1; ++j1)
                        tstat[5] += (tdata[i1, j1] - tstat[0]) * (tdata[i1, j1] - tstat[0]);
                matrixdata.Add(tdata);
                matrixstat.Add(tstat);
            }

            CallThread(MantelTestThread, N_THREAD,
                       new object[] { manteltext, matrixdata, mantelR },
            MANTEL_NPERM, ref MANTEL_CPERM);

            double p = 0;
            if (MANTEL_NSIG > MANTEL_NPERM / 2)
                p = (MANTEL_NSIG) / (MANTEL_NPERM + 1.0);
            else
                p = (MANTEL_NSIG + 1) / (MANTEL_NPERM + 1.0);

            // Output results
            StreamWriter wt = new StreamWriter(new FileStream("o_mantel.txt", FileMode.Create, FileAccess.Write), Encoding.UTF8);
            OUTPUT_MANTEL = wt;

            wt.Write("Matrix\tName\tMean\tVar\tMin\tMax\tSS\r\n");
            for (int i = 0; i < matrixname.Count; ++i)
            {
                wt.Write(i == 0 ? "X" : (i == 1 ? "Y" : ("Z" + (i - 1).ToString())));
                wt.Write("\t" + matrixname[i]);
                wt.Write("\t" + matrixstat[i][0].ToString(DECIMAL));
                wt.Write("\t" + matrixstat[i][2].ToString(DECIMAL));//Mean
                wt.Write("\t" + matrixstat[i][3].ToString(DECIMAL));//Var
                wt.Write("\t" + matrixstat[i][4].ToString(DECIMAL));//Min
                wt.Write("\t" + matrixstat[i][5].ToString(DECIMAL));//Max
                wt.Write("\r\n");
            }

            wt.Write("#Permutation = " + MANTEL_NPERM + "\r\n");
            wt.Write("#(r_perm > r) = " + MANTEL_NSIG + "\r\n");
            wt.Write("(Partial) correaltion r = " + mantelR[0].ToString(DECIMAL) + "\r\n");
            wt.Write("P(r_perm > r) = " + p.ToString(DECIMAL) + "\r\n");
            wt.Write("R-square = " + mantelR[1].ToString(DECIMAL) + "\r\n");
            wt.Write("Increase in R-square = " + mantelR[2].ToString(DECIMAL) + "\r\n");

            wt.Flush();
            wt.Close();
            runstate = GlobalRunState.mantelend;
        }

        private void MantelTestThread(object obj)
        {
            // Perform Mantel Test
            int id = (int)((object[])obj)[0];
            int nthreads = (int)((object[])obj)[1];
            string[,] manteltext = (string[,])((object[])obj)[2];
            List<double[,]> matrixdata = (List<double[,]>)((object[])obj)[3];
            double[] mantelR = (double[])((object[])obj)[4];

            double tr = MANTEL_NPERM / (double)nthreads + 1e-10;
            int nperm = (int)((id + 1) * tr) - (int)(id * tr);

            Random rnd = new Random(SEED ^ (id + 0x69353));
            int n = matrixdata[0].GetLength(0);
            double r = 0, r2 = 0, dr2 = 0;
            double[,] x = null, y = null, z1 = null, z2 = null, z3 = null, z4 = null, z5 = null;
            int[] xseq = GetIdxSeq(n);

            if (manteltext.GetLength(0) == (n + 1) * 2)
            {
                // Simple Mantel test
                y = matrixdata[0]; x = matrixdata[1];
                double xmean = 0, ymean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;

                double SSX = 0, SSY = 0;
                double z0 = 0;
                {
                    double SPXY = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);

                            SPXY += tx * ty;
                            SSX += tx * tx;
                            SSY += ty * ty;
                        }

                    r = SPXY / Math.Sqrt(SSX * SSY);
                    r2 = r * r;
                    dr2 = r * r;
                    z0 = SPXY;
                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);
                    double z = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                            z += (x[xseq[i], xseq[j]] - xmean) * (y[i, j] - ymean);

                    if (z > z0) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }
            else if (manteltext.GetLength(0) == (n + 1) * 3)
            {
                //Partial Mantel test controlling 1 matrix
                y = matrixdata[0]; x = matrixdata[1]; z1 = matrixdata[2];
                double xmean = 0, ymean = 0, zmean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                        zmean += z1[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;
                zmean /= n * (n - 1) / 2;

                double ryz1 = 1;
                double SPYZ1 = 0, SSX = 0, SSY = 0, SSZ1 = 0;
                {
                    double SPXY = 0, SPXZ1 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz = (z1[i, j] - zmean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz;
                            SPYZ1 += ty * tz;
                            SSX += tx * tx;
                            SSY += ty * ty;
                            SSZ1 += tz * tz;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    ryz1 = SPYZ1 / Math.Sqrt(SSY * SSZ1);
                    r = PartialCorr(rxy, rxz1, ryz1);

                    r2 = 1 - (1 - r * r) * (1 - ryz1 * ryz1);
                    dr2 = r2 - (1 - (1 - ryz1 * ryz1));
                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);

                    double SPXY = 0, SPXZ1 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz = (z1[i, j] - zmean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxyz = PartialCorr(rxy, rxz1, ryz1);
                    if (rxyz > r) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }
            else if (manteltext.GetLength(0) == (n + 1) * 4)
            {
                //Partial Mantel test controlling 2 matrices
                y = matrixdata[0]; x = matrixdata[1]; z1 = matrixdata[2]; z2 = matrixdata[3];
                double xmean = 0, ymean = 0, z1mean = 0, z2mean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                        z1mean += z1[i, j];
                        z2mean += z2[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;
                z1mean /= n * (n - 1) / 2;
                z2mean /= n * (n - 1) / 2;

                double ryz1 = 1, ryz2 = 1, rz1z2 = 1, ryz1_z2 = 1;
                double SPYZ1 = 0, SPYZ2 = 0, SPZ1Z2 = 0, SSX = 0, SSY = 0, SSZ1 = 0, SSZ2 = 0;
                {
                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPYZ1 += ty * tz1;
                            SPYZ2 += ty * tz2;
                            SPZ1Z2 += tz1 * tz2;
                            SSX += tx * tx;
                            SSY += ty * ty;
                            SSZ1 += tz1 * tz1;
                            SSZ2 += tz2 * tz2;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    ryz1 = SPYZ1 / Math.Sqrt(SSY * SSZ1);
                    ryz2 = SPYZ2 / Math.Sqrt(SSY * SSZ2);
                    rz1z2 = SPZ1Z2 / Math.Sqrt(SSZ1 * SSZ2);

                    double rxy_z2 = PartialCorr(rxy, rxz2, ryz2);
                    double rxz1_z2 = PartialCorr(rxz1, rxz2, rz1z2);
                    ryz1_z2 = PartialCorr(ryz1, ryz2, rz1z2);

                    r = PartialCorr(rxy_z2, rxz1_z2, ryz1_z2);

                    double rz1y_z2 = PartialCorr(ryz1, rz1z2, ryz2);
                    r2 = 1 - (1 - r * r) * (1 - rz1y_z2 * rz1y_z2) * (1 - ryz2 * ryz2);
                    dr2 = r2 - (1 - (1 - rz1y_z2 * rz1y_z2) * (1 - ryz2 * ryz2));
                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);

                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);

                    double rxy_z2 = PartialCorr(rxy, rxz2, ryz2);
                    double rxz1_z2 = PartialCorr(rxz1, rxz2, rz1z2);

                    double rxy_z1z2 = PartialCorr(rxy_z2, rxz1_z2, ryz1_z2);
                    if (rxy_z1z2 > r) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }
            else if (manteltext.GetLength(0) == (n + 1) * 5)
            {
                //Partial Mantel test controlling 3 matrices
                y = matrixdata[0]; x = matrixdata[1]; z1 = matrixdata[2]; z2 = matrixdata[3]; z3 = matrixdata[4];
                double xmean = 0, ymean = 0, z1mean = 0, z2mean = 0, z3mean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                        z1mean += z1[i, j];
                        z2mean += z2[i, j];
                        z3mean += z3[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;
                z1mean /= n * (n - 1) / 2;
                z2mean /= n * (n - 1) / 2;
                z3mean /= n * (n - 1) / 2;

                double ryz1 = 1, ryz2 = 1, ryz3 = 1, rz1z2 = 1, rz1z3 = 1, rz2z3 = 1, ryz1_z3 = 1, ryz2_z3 = 1, rz1z2_z3 = 1, ryz1_z2z3 = 0;
                double SPYZ1 = 0, SPYZ2 = 0, SPYZ3 = 0, SPZ1Z2 = 0, SPZ1Z3 = 0, SPZ2Z3 = 0, SSX = 0, SSY = 0, SSZ1 = 0, SSZ2 = 0, SSZ3 = 0;
                {
                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                            SPYZ1 += ty * tz1;
                            SPYZ2 += ty * tz2;
                            SPYZ3 += ty * tz3;
                            SPZ1Z2 += tz1 * tz2;
                            SPZ1Z3 += tz1 * tz3;
                            SPZ2Z3 += tz2 * tz3;
                            SSX += tx * tx;
                            SSY += ty * ty;
                            SSZ1 += tz1 * tz1;
                            SSZ2 += tz2 * tz2;
                            SSZ3 += tz3 * tz3;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);
                    ryz1 = SPYZ1 / Math.Sqrt(SSY * SSZ1);
                    ryz2 = SPYZ2 / Math.Sqrt(SSY * SSZ2);
                    ryz3 = SPYZ3 / Math.Sqrt(SSY * SSZ3);
                    rz1z2 = SPZ1Z2 / Math.Sqrt(SSZ1 * SSZ2);
                    rz1z3 = SPZ1Z3 / Math.Sqrt(SSZ1 * SSZ3);
                    rz2z3 = SPZ2Z3 / Math.Sqrt(SSZ2 * SSZ3);

                    double rxy_z3 = PartialCorr(rxy, rxz3, ryz3);
                    double rxz1_z3 = PartialCorr(rxz1, rxz3, rz1z3);
                    double rxz2_z3 = PartialCorr(rxz2, rxz3, rz2z3);
                    ryz1_z3 = PartialCorr(ryz1, ryz3, rz1z3);
                    ryz2_z3 = PartialCorr(ryz2, ryz3, rz2z3);
                    rz1z2_z3 = PartialCorr(rz1z2, rz1z3, rz2z3);

                    double rxy_z2z3 = PartialCorr(rxy_z3, rxz2_z3, ryz2_z3);
                    double rxz1_z2z3 = PartialCorr(rxz1_z3, rxz2_z3, rz1z2_z3);
                    ryz1_z2z3 = PartialCorr(ryz1_z3, ryz2_z3, rz1z2_z3);

                    r = PartialCorr(rxy_z2z3, rxz1_z2z3, ryz1_z2z3);

                    double rz1y_z3 = PartialCorr(ryz1, rz1z3, ryz3);
                    double rz2y_z3 = PartialCorr(ryz2, rz2z3, ryz3);
                    double rz1y_z2z3 = PartialCorr(rz1y_z3, rz1z2_z3, ryz2_z3);
                    r2 = 1 - (1 - r * r) * (1 - rz1y_z2z3 * rz1y_z2z3) * (1 - rz2y_z3 * rz2y_z3) * (1 - ryz3 * ryz3);
                    dr2 = r2 - (1 - (1 - rz1y_z2z3 * rz1y_z2z3) * (1 - rz2y_z3 * rz2y_z3) * (1 - ryz3 * ryz3));
                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);

                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);

                    double rxy_z3 = PartialCorr(rxy, rxz3, ryz3);
                    double rxz1_z3 = PartialCorr(rxz1, rxz3, rz1z3);
                    double rxz2_z3 = PartialCorr(rxz2, rxz3, rz2z3);

                    double rxy_z2z3 = PartialCorr(rxy_z3, rxz2_z3, ryz2_z3);
                    double rxz1_z2z3 = PartialCorr(rxz1_z3, rxz2_z3, rz1z2_z3);
                    double rxy_z1z2z3 = PartialCorr(rxy_z2z3, rxz1_z2z3, ryz1_z2z3);

                    if (rxy_z1z2z3 > r) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }
            else if (manteltext.GetLength(0) == (n + 1) * 6)
            {
                //Partial Mantel test controlling 4 matrices
                y = matrixdata[0]; x = matrixdata[1]; z1 = matrixdata[2]; z2 = matrixdata[3]; z3 = matrixdata[4]; z4 = matrixdata[5];
                double xmean = 0, ymean = 0, z1mean = 0, z2mean = 0, z3mean = 0, z4mean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                        z1mean += z1[i, j];
                        z2mean += z2[i, j];
                        z3mean += z3[i, j];
                        z4mean += z4[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;
                z1mean /= n * (n - 1) / 2;
                z2mean /= n * (n - 1) / 2;
                z3mean /= n * (n - 1) / 2;
                z4mean /= n * (n - 1) / 2;

                double ryz1 = 1, ryz2 = 1, ryz3 = 1, ryz4 = 1, rz1z2 = 1, rz1z3 = 1, rz1z4 = 1, rz2z3 = 1, rz2z4 = 1, rz3z4 = 1, ryz1_z4 = 1, ryz2_z4 = 1, ryz3_z4 = 1, rz1z2_z4 = 1, rz1z3_z4 = 1, rz2z3_z4 = 1, ryz1_z3z4 = 1, ryz2_z3z4 = 1, rz1z2_z3z4 = 1, ryz1_z2z3z4 = 1;
                double SPYZ1 = 0, SPYZ2 = 0, SPYZ3 = 0, SPYZ4 = 0, SPZ1Z2 = 0, SPZ1Z3 = 0, SPZ1Z4 = 0, SPZ2Z3 = 0, SPZ2Z4 = 0, SPZ3Z4 = 0, SSX = 0, SSY = 0, SSZ1 = 0, SSZ2 = 0, SSZ3 = 0, SSZ4 = 0;
                {
                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0, SPXZ4 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);
                            double tz4 = (z4[i, j] - z4mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                            SPXZ4 += tx * tz4;
                            SPYZ1 += ty * tz1;
                            SPYZ2 += ty * tz2;
                            SPYZ3 += ty * tz3;
                            SPYZ4 += ty * tz4;
                            SPZ1Z2 += tz1 * tz2;
                            SPZ1Z3 += tz1 * tz3;
                            SPZ1Z4 += tz1 * tz4;
                            SPZ2Z3 += tz2 * tz3;
                            SPZ2Z4 += tz2 * tz4;
                            SPZ3Z4 += tz3 * tz4;
                            SSX += tx * tx;
                            SSY += ty * ty;
                            SSZ1 += tz1 * tz1;
                            SSZ2 += tz2 * tz2;
                            SSZ3 += tz3 * tz3;
                            SSZ4 += tz4 * tz4;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);
                    double rxz4 = SPXZ4 / Math.Sqrt(SSX * SSZ4);
                    ryz1 = SPYZ1 / Math.Sqrt(SSY * SSZ1);
                    ryz2 = SPYZ2 / Math.Sqrt(SSY * SSZ2);
                    ryz3 = SPYZ3 / Math.Sqrt(SSY * SSZ3);
                    ryz4 = SPYZ4 / Math.Sqrt(SSY * SSZ4);
                    rz1z2 = SPZ1Z2 / Math.Sqrt(SSZ1 * SSZ2);
                    rz1z3 = SPZ1Z3 / Math.Sqrt(SSZ1 * SSZ3);
                    rz1z4 = SPZ1Z4 / Math.Sqrt(SSZ1 * SSZ4);
                    rz2z3 = SPZ2Z3 / Math.Sqrt(SSZ2 * SSZ3);
                    rz2z4 = SPZ2Z4 / Math.Sqrt(SSZ2 * SSZ4);
                    rz3z4 = SPZ3Z4 / Math.Sqrt(SSZ3 * SSZ4);

                    double rxy_z4 = PartialCorr(rxy, rxz4, ryz4);
                    double rxz1_z4 = PartialCorr(rxz1, rxz4, rz1z4);
                    double rxz2_z4 = PartialCorr(rxz2, rxz4, rz2z4);
                    double rxz3_z4 = PartialCorr(rxz3, rxz4, rz3z4);
                    ryz1_z4 = PartialCorr(ryz1, ryz4, rz1z4);
                    ryz2_z4 = PartialCorr(ryz2, ryz4, rz2z4);
                    ryz3_z4 = PartialCorr(ryz3, ryz4, rz3z4);
                    rz1z2_z4 = PartialCorr(rz1z2, rz1z4, rz2z4);
                    rz1z3_z4 = PartialCorr(rz1z3, rz1z4, rz3z4);
                    rz2z3_z4 = PartialCorr(rz2z3, rz2z4, rz3z4);

                    double rxy_z3z4 = PartialCorr(rxy_z4, rxz3_z4, ryz3_z4);
                    double rxz1_z3z4 = PartialCorr(rxz1_z4, rxz3_z4, rz1z3_z4);
                    double rxz2_z3z4 = PartialCorr(rxz2_z4, rxz3_z4, rz2z3_z4);
                    ryz1_z3z4 = PartialCorr(ryz1_z4, ryz3_z4, rz1z3_z4);
                    ryz2_z3z4 = PartialCorr(ryz2_z4, ryz3_z4, rz2z3_z4);
                    rz1z2_z3z4 = PartialCorr(rz1z2_z4, rz1z3_z4, rz2z3_z4);

                    double rxy_z2z3z4 = PartialCorr(rxy_z3z4, rxz2_z3z4, ryz2_z3z4);
                    double rxz1_z2z3z4 = PartialCorr(rxz1_z3z4, rxz2_z3z4, rz1z2_z3z4);
                    ryz1_z2z3z4 = PartialCorr(ryz1_z3z4, ryz2_z3z4, rz1z2_z3z4);

                    r = r = PartialCorr(rxy_z2z3z4, rxz1_z2z3z4, ryz1_z2z3z4);

                    double rz1y_z4 = PartialCorr(ryz1, rz1z4, ryz4);
                    double rz2y_z4 = PartialCorr(ryz2, rz2z4, ryz4);
                    double rz3y_z4 = PartialCorr(ryz3, rz3z4, ryz4);
                    double rz1y_z3z4 = PartialCorr(rz1y_z4, rz1z3_z4, ryz3_z4);
                    double rz2y_z3z4 = PartialCorr(rz2y_z4, rz2z3_z4, ryz3_z4);
                    double rz1y_z2z3z4 = PartialCorr(rz1y_z3z4, rz1z2_z3z4, ryz2_z3z4);
                    r2 = 1 - (1 - r * r) * (1 - rz1y_z2z3z4 * rz1y_z2z3z4) * (1 - rz2y_z3z4 * rz2y_z3z4) * (1 - rz3y_z4 * rz3y_z4) * (1 - ryz4 * ryz4);
                    dr2 = r2 - (1 - (1 - rz1y_z2z3z4 * rz1y_z2z3z4) * (1 - rz2y_z3z4 * rz2y_z3z4) * (1 - rz3y_z4 * rz3y_z4) * (1 - ryz4 * ryz4));
                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);

                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0, SPXZ4 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);
                            double tz4 = (z4[i, j] - z4mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                            SPXZ4 += tx * tz4;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);
                    double rxz4 = SPXZ4 / Math.Sqrt(SSX * SSZ4);

                    double rxy_z4 = PartialCorr(rxy, rxz4, ryz4);
                    double rxz1_z4 = PartialCorr(rxz1, rxz4, rz1z4);
                    double rxz2_z4 = PartialCorr(rxz2, rxz4, rz2z4);
                    double rxz3_z4 = PartialCorr(rxz3, rxz4, rz3z4);

                    double rxy_z3z4 = PartialCorr(rxy_z4, rxz3_z4, ryz3_z4);
                    double rxz1_z3z4 = PartialCorr(rxz1_z4, rxz3_z4, rz1z3_z4);
                    double rxz2_z3z4 = PartialCorr(rxz2_z4, rxz3_z4, rz2z3_z4);

                    double rxy_z2z3z4 = PartialCorr(rxy_z3z4, rxz2_z3z4, ryz2_z3z4);
                    double rxz1_z2z3z4 = PartialCorr(rxz1_z3z4, rxz2_z3z4, rz1z2_z3z4);

                    double rxy_z1z2z3z4 = PartialCorr(rxy_z2z3z4, rxz1_z2z3z4, ryz1_z2z3z4);

                    if (rxy_z1z2z3z4 > r) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }
            else if (manteltext.GetLength(0) == (n + 1) * 7)
            {
                //Partial Mantel test controlling 5 matrices
                y = matrixdata[0]; x = matrixdata[1]; z1 = matrixdata[2]; z2 = matrixdata[3]; z3 = matrixdata[4]; z4 = matrixdata[5]; z5 = matrixdata[6];
                double xmean = 0, ymean = 0, z1mean = 0, z2mean = 0, z3mean = 0, z4mean = 0, z5mean = 0;
                for (int i = 0; i < n; ++i)
                    for (int j = i + 1; j < n; ++j)
                    {
                        xmean += x[i, j];
                        ymean += y[i, j];
                        z1mean += z1[i, j];
                        z2mean += z2[i, j];
                        z3mean += z3[i, j];
                        z4mean += z4[i, j];
                        z5mean += z5[i, j];
                    }

                xmean /= n * (n - 1) / 2;
                ymean /= n * (n - 1) / 2;
                z1mean /= n * (n - 1) / 2;
                z2mean /= n * (n - 1) / 2;
                z3mean /= n * (n - 1) / 2;
                z4mean /= n * (n - 1) / 2;
                z5mean /= n * (n - 1) / 2;

                double ryz1 = 1, ryz2 = 1, ryz3 = 1, ryz4 = 1, ryz5 = 1, rz1z2 = 1, rz1z3 = 1, rz1z4 = 1, rz1z5 = 1, rz2z3 = 1, rz2z4 = 1, rz2z5 = 1, rz3z4 = 1, rz3z5 = 1, rz4z5 = 1, ryz1_z5 = 1, ryz2_z5 = 1, ryz3_z5 = 1, ryz4_z5 = 1, rz1z2_z5 = 1, rz1z3_z5 = 1, rz1z4_z5 = 1, rz2z3_z5 = 1, rz2z4_z5 = 1, rz3z4_z5 = 1, ryz1_z4z5 = 1, ryz2_z4z5 = 1, ryz3_z4z5 = 1, rz1z3_z4z5 = 1, rz1z2_z4z5 = 1, rz2z3_z4z5 = 1, ryz1_z3z4z5 = 1, ryz2_z3z4z5 = 1, rz1z2_z3z4z5 = 1, ryz1_z2z3z4z5 = 1;
                double SPYZ1 = 0, SPYZ2 = 0, SPYZ3 = 0, SPYZ4 = 0, SPYZ5 = 0, SPZ1Z2 = 0, SPZ1Z3 = 0, SPZ1Z4 = 0, SPZ1Z5 = 0, SPZ2Z3 = 0, SPZ2Z4 = 0, SPZ2Z5 = 0, SPZ3Z4 = 0, SPZ3Z5 = 0, SPZ4Z5 = 0, SSX = 0, SSY = 0, SSZ1 = 0, SSZ2 = 0, SSZ3 = 0, SSZ4 = 0, SSZ5 = 0;
                {
                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0, SPXZ4 = 0, SPXZ5 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);
                            double tz4 = (z4[i, j] - z4mean);
                            double tz5 = (z5[i, j] - z5mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                            SPXZ4 += tx * tz4;
                            SPXZ5 += tx * tz5;
                            SPYZ1 += ty * tz1;
                            SPYZ2 += ty * tz2;
                            SPYZ3 += ty * tz3;
                            SPYZ4 += ty * tz4;
                            SPYZ5 += ty * tz5;
                            SPZ1Z2 += tz1 * tz2;
                            SPZ1Z3 += tz1 * tz3;
                            SPZ1Z4 += tz1 * tz4;
                            SPZ1Z5 += tz1 * tz5;
                            SPZ2Z3 += tz2 * tz3;
                            SPZ2Z4 += tz2 * tz4;
                            SPZ2Z5 += tz2 * tz5;
                            SPZ3Z4 += tz3 * tz4;
                            SPZ3Z5 += tz3 * tz5;
                            SPZ4Z5 += tz4 * tz5;
                            SSX += tx * tx;
                            SSY += ty * ty;
                            SSZ1 += tz1 * tz1;
                            SSZ2 += tz2 * tz2;
                            SSZ3 += tz3 * tz3;
                            SSZ4 += tz4 * tz4;
                            SSZ5 += tz5 * tz5;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);
                    double rxz4 = SPXZ4 / Math.Sqrt(SSX * SSZ4);
                    double rxz5 = SPXZ5 / Math.Sqrt(SSX * SSZ5);
                    ryz1 = SPYZ1 / Math.Sqrt(SSY * SSZ1);
                    ryz2 = SPYZ2 / Math.Sqrt(SSY * SSZ2);
                    ryz3 = SPYZ3 / Math.Sqrt(SSY * SSZ3);
                    ryz4 = SPYZ4 / Math.Sqrt(SSY * SSZ4);
                    ryz5 = SPYZ5 / Math.Sqrt(SSY * SSZ5);
                    rz1z2 = SPZ1Z2 / Math.Sqrt(SSZ1 * SSZ2);
                    rz1z3 = SPZ1Z3 / Math.Sqrt(SSZ1 * SSZ3);
                    rz1z4 = SPZ1Z4 / Math.Sqrt(SSZ1 * SSZ4);
                    rz1z5 = SPZ1Z5 / Math.Sqrt(SSZ1 * SSZ5);
                    rz2z3 = SPZ2Z3 / Math.Sqrt(SSZ2 * SSZ3);
                    rz2z4 = SPZ2Z4 / Math.Sqrt(SSZ2 * SSZ4);
                    rz2z5 = SPZ2Z5 / Math.Sqrt(SSZ2 * SSZ5);
                    rz3z4 = SPZ3Z4 / Math.Sqrt(SSZ3 * SSZ4);
                    rz3z5 = SPZ3Z5 / Math.Sqrt(SSZ3 * SSZ5);
                    rz4z5 = SPZ4Z5 / Math.Sqrt(SSZ4 * SSZ5);

                    double rxy_z5 = PartialCorr(rxy, rxz5, ryz5);
                    double rxz1_z5 = PartialCorr(rxz1, rxz5, rz1z5);
                    double rxz2_z5 = PartialCorr(rxz2, rxz5, rz2z5);
                    double rxz3_z5 = PartialCorr(rxz3, rxz5, rz3z5);
                    double rxz4_z5 = PartialCorr(rxz4, rxz5, rz4z5);
                    ryz1_z5 = PartialCorr(ryz1, ryz5, rz1z5);
                    ryz2_z5 = PartialCorr(ryz2, ryz5, rz2z5);
                    ryz3_z5 = PartialCorr(ryz3, ryz5, rz3z5);
                    ryz4_z5 = PartialCorr(ryz4, ryz5, rz4z5);
                    rz1z2_z5 = PartialCorr(rz1z2, rz1z5, rz2z5);
                    rz1z3_z5 = PartialCorr(rz1z3, rz1z5, rz3z5);
                    rz1z4_z5 = PartialCorr(rz1z4, rz1z5, rz4z5);
                    rz2z4_z5 = PartialCorr(rz2z4, rz2z5, rz4z5);
                    rz2z3_z5 = PartialCorr(rz2z3, rz2z5, rz3z5);
                    rz3z4_z5 = PartialCorr(rz3z4, rz3z5, rz4z5);

                    double rxy_z4z5 = PartialCorr(rxy_z5, rxz4_z5, ryz4_z5);
                    double rxz1_z4z5 = PartialCorr(rxz1_z5, rxz4_z5, rz1z4_z5);
                    double rxz2_z4z5 = PartialCorr(rxz2_z5, rxz4_z5, rz2z4_z5);
                    double rxz3_z4z5 = PartialCorr(rxz3_z5, rxz4_z5, rz3z4_z5);
                    ryz1_z4z5 = PartialCorr(ryz1_z5, ryz4_z5, rz1z4_z5);
                    ryz2_z4z5 = PartialCorr(ryz2_z5, ryz4_z5, rz2z4_z5);
                    ryz3_z4z5 = PartialCorr(ryz3_z5, ryz4_z5, rz3z4_z5);
                    rz1z3_z4z5 = PartialCorr(rz1z3_z5, rz1z4_z5, rz3z4_z5);
                    rz1z2_z4z5 = PartialCorr(rz1z2_z5, rz1z4_z5, rz2z4_z5);
                    rz2z3_z4z5 = PartialCorr(rz2z3_z5, rz2z4_z5, rz3z4_z5);

                    double rxy_z3z4z5 = PartialCorr(rxy_z4z5, rxz3_z4z5, ryz3_z4z5);
                    double rxz1_z3z4z5 = PartialCorr(rxz1_z4z5, rxz3_z4z5, rz1z3_z4z5);
                    double rxz2_z3z4z5 = PartialCorr(rxz2_z4z5, rxz3_z4z5, rz2z3_z4z5);
                    ryz1_z3z4z5 = PartialCorr(ryz1_z4z5, ryz3_z4z5, rz1z3_z4z5);
                    ryz2_z3z4z5 = PartialCorr(ryz2_z4z5, ryz3_z4z5, rz2z3_z4z5);
                    rz1z2_z3z4z5 = PartialCorr(rz1z2_z4z5, rz1z3_z4z5, rz2z3_z4z5);

                    double rxy_z2z3z4z5 = PartialCorr(rxy_z3z4z5, rxz2_z3z4z5, ryz2_z3z4z5);
                    double rxz1_z2z3z4z5 = PartialCorr(rxz1_z3z4z5, rxz2_z3z4z5, rz1z2_z3z4z5);
                    ryz1_z2z3z4z5 = PartialCorr(ryz1_z3z4z5, ryz2_z3z4z5, rz1z2_z3z4z5);

                    r = PartialCorr(rxy_z2z3z4z5, rxz1_z2z3z4z5, ryz1_z2z3z4z5);

                    double rz1y_z5 = PartialCorr(ryz1, rz1z5, ryz5);
                    double rz2y_z5 = PartialCorr(ryz2, rz2z5, ryz5);
                    double rz3y_z5 = PartialCorr(ryz3, rz3z5, ryz5);
                    double rz4y_z5 = PartialCorr(ryz4, rz4z5, ryz5);
                    double rz1y_z4z5 = PartialCorr(rz1y_z5, rz1z4_z5, ryz4_z5);
                    double rz2y_z4z5 = PartialCorr(rz2y_z5, rz2z4_z5, ryz4_z5);
                    double rz3y_z4z5 = PartialCorr(rz3y_z5, rz3z4_z5, ryz4_z5);
                    double rz1y_z3z4z5 = PartialCorr(rz1y_z4z5, rz1z3_z4z5, ryz3_z4z5);
                    double rz2y_z3z4z5 = PartialCorr(rz2y_z4z5, rz2z3_z4z5, ryz3_z4z5);
                    double rz1y_z2z3z4z5 = PartialCorr(rz1y_z3z4z5, rz1z2_z3z4z5, ryz2_z3z4z5);

                    r2 = 1 - (1 - r * r) * (1 - rz1y_z2z3z4z5 * rz1y_z2z3z4z5) * (1 - rz2y_z3z4z5 * rz2y_z3z4z5) * (1 - rz3y_z4z5 * rz3y_z4z5) * (1 - rz4y_z5 * rz4y_z5) * (1 - ryz5 * ryz5);
                    dr2 = r2 - (1 - (1 - rz1y_z2z3z4z5 * rz1y_z2z3z4z5) * (1 - rz2y_z3z4z5 * rz2y_z3z4z5) * (1 - rz3y_z4z5 * rz3y_z4z5) * (1 - rz4y_z5 * rz4y_z5) * (1 - ryz5 * ryz5));

                }

                for (int k = 0; k < nperm; ++k)
                {
                    //Permute(xseq, rnd);
                    GetRandSeq(xseq, rnd);

                    double SPXY = 0, SPXZ1 = 0, SPXZ2 = 0, SPXZ3 = 0, SPXZ4 = 0, SPXZ5 = 0;
                    for (int i = 0; i < n; ++i)
                        for (int j = i + 1; j < n; ++j)
                        {
                            double tx = (x[xseq[i], xseq[j]] - xmean);
                            double ty = (y[i, j] - ymean);
                            double tz1 = (z1[i, j] - z1mean);
                            double tz2 = (z2[i, j] - z2mean);
                            double tz3 = (z3[i, j] - z3mean);
                            double tz4 = (z4[i, j] - z4mean);
                            double tz5 = (z5[i, j] - z5mean);

                            SPXY += tx * ty;
                            SPXZ1 += tx * tz1;
                            SPXZ2 += tx * tz2;
                            SPXZ3 += tx * tz3;
                            SPXZ4 += tx * tz4;
                            SPXZ5 += tx * tz5;
                        }

                    double rxy = SPXY / Math.Sqrt(SSX * SSY);
                    double rxz1 = SPXZ1 / Math.Sqrt(SSX * SSZ1);
                    double rxz2 = SPXZ2 / Math.Sqrt(SSX * SSZ2);
                    double rxz3 = SPXZ3 / Math.Sqrt(SSX * SSZ3);
                    double rxz4 = SPXZ4 / Math.Sqrt(SSX * SSZ4);
                    double rxz5 = SPXZ5 / Math.Sqrt(SSX * SSZ5);

                    double rxy_z5 = PartialCorr(rxy, rxz5, ryz5);
                    double rxz1_z5 = PartialCorr(rxz1, rxz5, rz1z5);
                    double rxz2_z5 = PartialCorr(rxz2, rxz5, rz2z5);
                    double rxz3_z5 = PartialCorr(rxz3, rxz5, rz3z5);
                    double rxz4_z5 = PartialCorr(rxz4, rxz5, rz4z5);

                    double rxy_z4z5 = PartialCorr(rxy_z5, rxz4_z5, ryz4_z5);
                    double rxz1_z4z5 = PartialCorr(rxz1_z5, rxz4_z5, rz1z4_z5);
                    double rxz2_z4z5 = PartialCorr(rxz2_z5, rxz4_z5, rz2z4_z5);
                    double rxz3_z4z5 = PartialCorr(rxz3_z5, rxz4_z5, rz3z4_z5);

                    double rxy_z3z4z5 = PartialCorr(rxy_z4z5, rxz3_z4z5, ryz3_z4z5);
                    double rxz1_z3z4z5 = PartialCorr(rxz1_z4z5, rxz3_z4z5, rz1z3_z4z5);
                    double rxz2_z3z4z5 = PartialCorr(rxz2_z4z5, rxz3_z4z5, rz2z3_z4z5);

                    double rxy_z2z3z4z5 = PartialCorr(rxy_z3z4z5, rxz2_z3z4z5, ryz2_z3z4z5);
                    double rxz1_z2z3z4z5 = PartialCorr(rxz1_z3z4z5, rxz2_z3z4z5, rz1z2_z3z4z5);

                    double rxy_z1z2z3z4z5 = PartialCorr(rxy_z2z3z4z5, rxz1_z2z3z4z5, ryz1_z2z3z4z5);

                    if (rxy_z1z2z3z4z5 > r) Interlocked.Increment(ref MANTEL_NSIG);
                    Interlocked.Increment(ref MANTEL_CPERM);
                }
            }

            mantelR[0] = r;
            mantelR[1] = r2;
            mantelR[2] = dr2;
        }

        private void MantelExample(object sender, EventArgs e)
        {
            // Reset example dataset
            MantelMatBox.Text = @"Genetic	pop1	pop2	pop3	pop4
pop1	0.00	0.28	0.17	0.21
pop2	0.28	0.00	0.23	0.35
pop3	0.17	0.23	0.00	0.24
pop4	0.21	0.35	0.24	0.00
Geographic	pop1	pop2	pop3	pop4
pop1	0.00	4667.49	20561.42	36215.94
pop2	4667.49	0.00	18759.69	31643.91
pop3	20561.42	18759.69	0.00	27984.49
pop4	36215.94	31643.91	27984.49	0.00";
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Jump to a url
            System.Diagnostics.Process.Start("https://github.com/huangkang1987/isolation");
        }

        #endregion

        #region STRUCTURE_SIM

        private void StructureSim(object sender, EventArgs e)
        {
            //1. Initialize
            int K = 4, N = 200, S = 4, L = 500;
            double Fst = 0.99;
            double s = 1e300; //admix intensity
            Random rnd = new Random();

            //2. Generate ancestral allele freq
            double[] F = new double[L];
            for (int l = 0; l < L; ++l)
                F[l] = 0.5;// rnd.NextDouble() * 0.8 + 0.5;

            //3. Generate cluster allele freq via Dirichlet Distribution
            double[,] Fk = new double[L, K];
            double gamma = 1.0 / Fst - 1;
            for (int l = 0; l < L; ++l)
            {
                for (int k = 0; k < K; ++k)
                {
                    double g1 = GetRandGamma(rnd, gamma * F[l]);
                    double g2 = GetRandGamma(rnd, gamma * (1 - F[l]));
                    Fk[l, k] = g1 / (g1 + g2);
                }
            }

            //4. Obtain admix proportion for each individual
            double[,] Q = new double[N, K];
            for (int k = 0; k < K - 1; ++k)
            {
                double c = s > 100 ? (k + 1) / K :
                    (Math.Log(1 - Math.Exp(-k * s)) - Math.Log(Math.Exp(-k * s) - Math.Exp(-K * s))) / (s * K);
                for (int i = 0; i < N; ++i)
                    Q[i, k] = 1 / (1 + Math.Exp((((i + 0.5) / N) - c) * K * s));
            }

            for (int i = 0; i < N; ++i)
            {
                Q[i, K - 1] = 1;
                for (int k = K - 1; k > 0; --k)
                    Q[i, k] -= Q[i, k - 1];
            }

            //5. Weight for allele frequency for each individual
            //6. Generate genotype for each individual
            //7. Write genotype and phenotype file
            StringBuilder sbG = new StringBuilder();
            StringBuilder sbP = new StringBuilder();
            sbG.Append("Ind\tPop\tPloidy");
            sbP.Append("Ind\tPop\tPloidy");
            for (int l = 0; l < L; ++l)
            {
                sbG.Append("\tl" + (l + 1));
                sbP.Append("\tl" + (l + 1));
            }

            int SN = N / S;
            for (int i = 0; i < N; ++i)
            {
                sbG.Append("\r\nI" + (i + 1) + "\tP" + (i / SN + 1) + "\t4");
                sbP.Append("\r\nI" + (i + 1) + "\tP" + (i / SN + 1) + "\t4");
                for (int l = 0; l < L; ++l)
                {
                    double f = 0;
                    for (int k = 0; k < K; ++k)
                        f += Fk[l, k] * Q[i, k];

                    int g = 0;
                    for (int j = 0; j < 4; ++j)
                        if (rnd.NextDouble() < f)
                            g++;

                    sbG.Append("\t" + g);
                    switch (g)
                    {
                        default:
                        case 0:
                            sbP.Append("\t1");
                            break;
                        case 1:
                        case 2:
                        case 3:
                            sbP.Append("\t1,2");
                            break;
                        case 4:
                            sbP.Append("\t2");
                            break;
                    }
                }
            }

            if (true)
            {
                PhenotypeBox.Text = sbG.ToString();
                FormatBox.SelectedIndex = 2;
            }
            else
            {
                PhenotypeBox.Text = sbP.ToString();
                FormatBox.SelectedIndex = 0;
            }

        }

        #endregion

        #region UI

        #region FORM4
        public bool MODEL_TEST = false;
        private void ModelTestButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = InputPage;
            f4.ShowDialog();
        }

        public void ModelTest()
        {
            // Find the optimal allele frequency model by AICc/BIC
            if (runstate == GlobalRunState.running || runstate == GlobalRunState.mantelrunning || runstate == GlobalRunState.simulating || runstate == GlobalRunState.end) return;
            MODEL_TEST = true;
            bool[] cbch = new bool[GroupBoxMethods.Controls.Count + 6];
            int e1 = 0, e2 = 0;
            new Task(() => {
                BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < GroupBoxMethods.Controls.Count; ++i)
                    {
                        CheckBox cb = (CheckBox)GroupBoxMethods.Controls[i];
                        cbch[i] = cb.Checked;
                        cb.Checked = false;
                    }
                    CalcDistributionBox.Checked = true;

                    cbch[GroupBoxMethods.Controls.Count + 0] = PhenotypeTestPopBox.Checked;
                    cbch[GroupBoxMethods.Controls.Count + 1] = PhenotypeTestRegBox.Checked;
                    cbch[GroupBoxMethods.Controls.Count + 2] = PhenotypeTestTotBox.Checked;
                    cbch[GroupBoxMethods.Controls.Count + 3] = FrequencySelfingBox.Checked;
                    cbch[GroupBoxMethods.Controls.Count + 4] = FrequencyNegPCRBox.Checked;
                    cbch[GroupBoxMethods.Controls.Count + 5] = FrequencyNullAlleleBox.Checked;
                    e1 = FrequencyInheritanceModeBox.SelectedIndex;
                    e2 = FrequencySelfingRateEstimatorBox.SelectedIndex;

                    PhenotypeTestPopBox.Checked = true;
                    PhenotypeTestRegBox.Checked = false;
                    PhenotypeTestTotBox.Checked = false;
                }));
            }).Start();

            string[] DR = new string[] { "RCS", "PRCS", "CES", "PES + rs = 0.25", "PES + rs = 0.5", "PES + rs" };
            string[] SELF = new string[] { "", " + s(ML)", " + s(Fz)", " + s(g2z)" };
            string[] PY = new string[] { "", " + py" };
            string[] BETA = new string[] { "", " + beta" };

            StringBuilder re = new StringBuilder();
            re.Append("Model\tln L\t#par\t#genotypes/phenotypes\tAICc\tBIC\r\n");
            int nmodel = 0;

            for (int dr = 0; dr < 6; ++dr) if (f4.drc[dr])
                    for (int self = 0; self < (dr == 5 ? 1 : 4); ++self) if (f4.selfc[self])
                            for (int py = 0; py < 2; ++py) if (f4.pyc[py])
                                    for (int beta = 0; beta < 2; ++beta) if (f4.betac[beta])
                                            nmodel++;

            new Task(() => { BeginInvoke(new Action(() => { f4.toolStripProgressBar1.Maximum = nmodel; })); }).Start();

            for (int dr = 0, c = 0; dr < 6; ++dr) if (f4.drc[dr])
                    for (int self = 0; self < (dr == 5 ? 1 : 4); ++self) if (f4.selfc[self])
                            for (int py = 0; py < 2; ++py) if (f4.pyc[py])
                                    for (int beta = 0; beta < 2; ++beta) if (f4.betac[beta])
                                        {
                                            string str = DR[dr] + SELF[self] + PY[py] + BETA[beta];
                                            new Task(() => {
                                                BeginInvoke(new Action(() => {
                                                    FrequencyInheritanceModeBox.SelectedIndex = dr;
                                                    FrequencySelfingRateEstimatorBox.SelectedIndex = self - 1 < 0 ? 0 : self - 1;
                                                    FrequencySelfingBox.Checked = self > 0;
                                                    FrequencyNegPCRBox.Checked = beta > 0;
                                                    FrequencyNullAlleleBox.Checked = py > 0;
                                                    runstate = GlobalRunState.notstart;
                                                    BeginCalculation(null, null);
                                                    f4.ModelText.Text = str;
                                                }));
                                            }).Start();

                                            Thread.Sleep(1000);
                                            while (runstate != GlobalRunState.notstart) Thread.Sleep(200);
                                            re.Append(str + "\t" + all.modelteststr);
                                            new Task(() => {
                                                BeginInvoke(new Action(() => {
                                                    f4.ModelTestResBox.Text = re.ToString();
                                                    f4.toolStripProgressBar1.Value = ++c;
                                                }));
                                            }).Start();
                                        }

            new Task(() => {
                BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < GroupBoxMethods.Controls.Count; ++i)
                    {
                        CheckBox cb = (CheckBox)GroupBoxMethods.Controls[i];
                        cb.Checked = cbch[i];
                    }
                    PhenotypeTestPopBox.Checked = cbch[GroupBoxMethods.Controls.Count + 0];
                    PhenotypeTestRegBox.Checked = cbch[GroupBoxMethods.Controls.Count + 1];
                    PhenotypeTestTotBox.Checked = cbch[GroupBoxMethods.Controls.Count + 2];
                    FrequencySelfingBox.Checked = cbch[GroupBoxMethods.Controls.Count + 3];
                    FrequencyNegPCRBox.Checked = cbch[GroupBoxMethods.Controls.Count + 4];
                    FrequencyNullAlleleBox.Checked = cbch[GroupBoxMethods.Controls.Count + 5];
                    FrequencyInheritanceModeBox.SelectedIndex = e1;
                    FrequencySelfingRateEstimatorBox.SelectedIndex = e2;
                    f4.ModelTestResBox.Text = re.ToString();
                    f4.groupBox1.Enabled = true;
                }));
            }).Start();
            MODEL_TEST = false;
        }
        #endregion

        #region FORM5 

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            f5.ShowDialog();
            runstate = GlobalRunState.notstart;
        }

        public void ExportDummyGenotype()
        {
            // Export dummy genotype files

            // The true genotype may be unknown, so we can generate some diploid genotype or polyploid genotype
            // then output the genotype into files and use other software (e.g. structure, bayesass)
            // to perform further analyses

            if (runstate == GlobalRunState.running || runstate == GlobalRunState.mantelrunning || runstate == GlobalRunState.simulating || runstate == GlobalRunState.end) return;

            bool[] cbch = new bool[GroupBoxMethods.Controls.Count + 6];
            new Task(() => {
                BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < GroupBoxMethods.Controls.Count; ++i)
                    {
                        CheckBox cb = (CheckBox)GroupBoxMethods.Controls[i];
                        cbch[i] = cb.Checked;
                        cb.Checked = false;
                    }
                }));
            }).Start();


            new Task(() => {
                BeginInvoke(new Action(() =>
                {
                    runstate = GlobalRunState.notstart;
                    BeginCalculation(null, null);
                }));
            }).Start();

            Thread.Sleep(2000);
            while (runstate != GlobalRunState.notstart) Thread.Sleep(200);
            if (all == null || all.total_pop == null || all.total_pop.loc == null ||
                all.total_pop.loc[0] == null || all.total_pop.loc[0].freq == null ||
                all.total_pop.loc[0].freq.Values.Sum() < 0.1) return;
            ExportMethod method = f5.method;
            ExportFormat format = f5.format;
            bool fillmissing = f5.fillmissing;
            int rep = f5.rep;
            int nfiles = f5.nfiles;
            int nullid = f5.nullid;
            int maxn = f5.maxn;
            string dir = f5.dir;

            Parallel.For(0, nfiles, new ParallelOptions() { MaxDegreeOfParallelism = N_THREAD }, i =>
            {
                all.ExportDummyGenotype(method, format, fillmissing, rep, nullid, dir + "\\" + (i + 1).ToString() + ".txt", SEED + i, maxn);
                new Task(() => { BeginInvoke(new Action(() => { f5.toolStripProgressBar1.Value++; })); }).Start();
            });

            new Task(() => {
                BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < GroupBoxMethods.Controls.Count; ++i)
                    {
                        CheckBox cb = (CheckBox)GroupBoxMethods.Controls[i];
                        cb.Checked = cbch[i];
                    }
                    f5.groupBox1.Enabled = true;
                }));
            }).Start();
        }

        #endregion

        #region FORM1
        public Form1(string[] args)
        {
            ARGS = args;
            for (int i = 0; i < ARGS.Length; ++i)
            {
                ARGS[i] = ARGS[i].Replace("\r", "").Replace("\n", "");
            }
            InitializeComponent();
            f3 = new Form3(this);
            f4 = new Form4(this);
            f5 = new Form5(this);
            f6 = new Form6(this);
        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            // Use two buffers to accelerate UI display

            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        private void EnableDoubleBuffering(Control parent)
        {
            // Use two buffers to accelerate UI display
            foreach (Control c in parent.Controls)
            {
                SetDoubleBuffered(c);
                EnableDoubleBuffering(c);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffering(this);

            // Obtain amplification scale for high-resolution screens
            DPI_SCALE = this.CreateGraphics().DpiX / 96.0f;

            // Executable path
            Process pr = new Process
            {
                StartInfo = { UseShellExecute = false, RedirectStandardOutput = true,
                    FileName = "uname", Arguments = "-s"  }
            };
            string uname = "";
            try
            {
                pr.Start();
                uname = pr.StandardOutput.ReadToEnd().Trim();
            }
            catch { }

            // Obtain current operation system
            if (uname.ToLower().Contains("darwin")) OS = OperationSystem.MacOSX;
            else if (Environment.OSVersion.Platform == PlatformID.Unix) OS = OperationSystem.Linux;
            else OS = OperationSystem.Windows;

            // Initialize
            DELIM = OS == OperationSystem.Windows ? "\\" : "/";
            cdir = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            cdir = cdir.Substring(0, cdir.LastIndexOf(DELIM) + 1);
            Directory.SetCurrentDirectory(cdir);
            resdir = cdir + "Results" + DELIM;
            if (!Directory.Exists(resdir))
                Directory.CreateDirectory(resdir);

            // Clean result folder if it exceeds 1 Gib
            long tsize = new DirectoryInfo(resdir).GetFiles("*").Sum(f => f.Length);
            if (tsize > 1024 * 1024 * 1024)
                MessageBox.Show("Files in Results directory exceeds " + ((double)tsize / 1024 / 1024).ToString("F2") + " MiB. Please delete some unused files. ");

            // Adjustment UI controls
            f1 = this;
            LoadLibrary();
            StructureIndividualOrderBox.SelectedIndex = 0;
            StructureRearrangeColorBox.SelectedIndex = 1;
            FrequencySelfingRateEstimatorBox.SelectedIndex = 0;
            FrequencyInheritanceModeBox.SelectedIndex = 0;
            ParentageEstErrorBox.SelectedIndex = 0;
            ParentageMethodBox.SelectedIndex = 0;
            ParentageOutputBox.SelectedIndex = 0;
            NeWaplesMSBox.SelectedIndex = 0;
            FormatBox.SelectedIndex = 0;
            OrdinationStyleBox.SelectedIndex = 0;
            SpatialDistClassBox.SelectedIndex = 0;
            BayesAssMethodBox.SelectedIndex = 3;
            BayesAssPlotStyleBox.SelectedIndex = 0;

            MouseWheel += Form1_MouseWheel;

            splitContainer9.SplitterDistance = (splitContainer9.Height - 24) / 3;
            splitContainer10.SplitterDistance = (splitContainer10.Height - 16) / 2;
            splitContainer13.SplitterDistance = (splitContainer13.Height - 16) / 2;
            splitContainer12.SplitterDistance = 4 + D1_80.Right + 20;
            splitContainer4.SplitterDistance = 4 + linkLabel2.Right + 20;
            splitContainer5.SplitterDistance = 4 + linkLabel2.Bottom + 20;
            splitContainer14.SplitterDistance = splitContainer14.Width - (4 + SimPop_DistBox.Right + 20);
            splitContainer16.SplitterDistance = (splitContainer16.Width - 8) / 2;
            splitContainer8.SplitterDistance = (splitContainer8.Height - 8) / 2;
            splitContainer3.SplitterDistance = (splitContainer3.Height - 8) / 2;
            splitContainer18.SplitterDistance = (splitContainer18.Height - 8) / 2;
            splitContainer20.SplitterDistance = GroupBoxMethods.Width + 8;

            SaveStructureButton.Tag = StructurePicBox;
            SaveBayesAssButton.Tag = BayesAssPicBox;
            SaveClusteringButton.Tag = ClusteringPicBox;
            SaveOrdinationButton.Tag = OrdinationPicBox;
            ClusteringPreviousButton.Tag = ClusteringComboBox;
            ClusteringNextButton.Tag = ClusteringComboBox;
            OrdinationPreviousButton.Tag = OrdinationComboBox;
            OrdinationNextButton.Tag = OrdinationComboBox;

            // Configure some global variables
            ISLOADING = true;
            PrepareCryptTable();
            BINOMIAL = new double[MAX_ALLELES + 14, MAX_ALLELES + 14];//small big
            for (int i = 0; i < MAX_ALLELES + 14; ++i)
                for (int j = 0; j <= i; ++j)
                    BINOMIAL[i, j] = Binomial(i, j);

            for (int p = 1; p <= MAX_PLOIDY; ++p)
            {
                for (int k = 1; k <= MAX_ALLELES + 1; ++k)
                {
                    int ex = Math.Min(k, p);
                    for (int i = 1; i <= ex; ++i)
                        PHENO_COUNT[p, k] += BINOMIAL[k, i];
                    PHENO_COUNT[p, k] = Math.Round(PHENO_COUNT[p, k]);
                }
            }

            // Load configuration from config.ini
            LoadSettings();
            ISLOADING = false;
            ApplySettings();

            // Load result files for structure and bayesass
            LoadStructureResultFiles();
            LoadBayesAssResultFiles();
            ShowPanel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save and notice before exit

            SaveSettings();
            if (REMIND_WARNING)
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure to quit polygene?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                    System.Environment.Exit(0);
                else
                    e.Cancel = true;
            }
            else
                System.Environment.Exit(0);
        }

        private Process[] proc;

        private void RunCommand(object sender, EventArgs e)
        {
            //this.ShowIcon = false;
            this.WindowState = FormWindowState.Minimized;
            int n = (Environment.ProcessorCount == 12 ? 6 : Environment.ProcessorCount) / 2;
            Random grnd = new Random();
            proc = new Process[n];
            string[] name = new string[n];
            DateTime[] time = new DateTime[n];

            for (int i = 0; i < n; ++i)
            {
                time[i] = DateTime.Now;
                name[i] = "";
            }

            for (; ; )
            {
                string[] cmd2 = SimPop_AlleleFrequencyBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> cmd = new List<string>();

                for (int i = 0; i < cmd2.Length; ++i)
                {
                    string[] con = cmd2[i % cmd2.Length].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (con[0] == "PARENT1" && con[10] == "6") n = 10;
                    if (con[0] == "PARENT2" && con[7] == "6") n = 10;
                    if (con[0] == "PARENT3") n = (Environment.ProcessorCount == 12 ? 6 : Environment.ProcessorCount) / 4;
                    if (con[0] == "AMOVA" && !File.Exists("samova" + DELIM + con[1] + "_1.txt"))
                    {
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));
                        continue;
                    }
                    if (con[0] == "PARENT1" && !File.Exists("PAPP1" + DELIM + con[1] + ".txt"))
                    {
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));
                        continue;
                    }
                    if (con[0] == "PARENT2" && !File.Exists("PAPP2" + DELIM + con[1] + ".txt"))
                    {
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));
                        continue;
                    }
                    if (con[0] == "PARENT3" && !File.Exists("PAPP3" + DELIM + con[1] + ".txt"))
                    {
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));
                        continue;
                    }

                    int ncalced = 0;
                    switch (con[0])
                    {
                        case "AMOVA":
                            ncalced = File.ReadAllLines("samova" + DELIM + con[1] + "_1.txt").Length;
                            break;
                        case "PARENT1":
                            ncalced = File.ReadAllLines("PAPP1" + DELIM + con[1] + ".txt").Length;
                            break;
                        case "PARENT2":
                            ncalced = File.ReadAllLines("PAPP2" + DELIM + con[1] + ".txt").Length;
                            break;
                        case "PARENT3":
                            ncalced = File.ReadAllLines("PAPP3" + DELIM + con[1] + ".txt").Length;
                            break;
                    }

                    if (con[0] == "AMOVA" && int.Parse(con[8]) > ncalced)
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));

                    if (con[0] == "PARENT1" && int.Parse(con[4]) > ncalced)
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));

                    if (con[0] == "PARENT2" && int.Parse(con[6]) > ncalced)
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));

                    if (con[0] == "PARENT3" && int.Parse(con[4]) > ncalced)
                        cmd.Add(cmd2[i % cmd2.Length].Replace("\t", " "));
                }

                if (cmd.Count == 0) break;

                int ll = cmd.Count;
                while (cmd.Count < n)
                    cmd.Add(cmd[grnd.Next(ll)]);

                int[] seq = new int[cmd.Count];
                GetRandSeq(seq, grnd);

                int cmdp = 0;
                string path = Environment.GetCommandLineArgs()[0];

                while (cmdp < cmd.Count)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        this.Text = cmdp + " / " + cmd.Count;
                        if (cmdp >= seq.Length) continue;

                        if (proc[i] == null || proc[i].HasExited)
                        {
                            proc[i] = Process.Start(path.Replace(".vshost", ""), cmd[seq[cmdp++]]);
                            time[i] = DateTime.Now;
                            Thread.Sleep(1000);
                        }

                        if ((DateTime.Now - time[i]).Minutes >= 100000)
                        {
                            time[i] = DateTime.Now;

                            StringBuilder re = new StringBuilder(5120);
                            GetWindowText(proc[i].MainWindowHandle, re, re.Capacity);

                            if (name[i] != re.ToString())
                                name[i] = re.ToString();
                            else
                            {
                                while (!proc[i].HasExited)
                                {
                                    Process.Start("ntsd.exe", "-c q -p " + proc[i].Id);
                                    Thread.Sleep(1000);
                                    Process.Start("taskkill.exe", "/IM ntsd.exe /f ");
                                    Thread.Sleep(1000);
                                }
                            }
                        }

                    }
                    Thread.Sleep(1000);
                }
            }
        }

        #endregion

        #region SETTINGS
        private void LoadSettings()
        {
            // Load configurations from config.ini

            try
            {
                string[] a = File.ReadAllText(cdir + "config.ini", Encoding.UTF8).Split(new string[] { IDENTIFIER }, StringSplitOptions.None);
                int c = 0;

                //Calculation
                CalcDistributionBox.Checked = bool.Parse(a[c++]);
                CalcLinkageBox.Checked = bool.Parse(a[c++]);
                CalcNeBox.Checked = bool.Parse(a[c++]);
                CalcDiffBox.Checked = bool.Parse(a[c++]);
                CalcDistBox.Checked = bool.Parse(a[c++]);
                CalcOrdinationBox.Checked = bool.Parse(a[c++]);
                CalcClusteringBox.Checked = bool.Parse(a[c++]);
                CalcInbreedingBox.Checked = bool.Parse(a[c++]);
                CalcHIndexBox.Checked = bool.Parse(a[c++]);
                CalcAssignmentBox.Checked = bool.Parse(a[c++]);
                CalcSpatialBox.Checked = bool.Parse(a[c++]);
                CalcRelationshipBox.Checked = bool.Parse(a[c++]);
                CalcHeritabilityBox.Checked = bool.Parse(a[c++]);
                CalcQstBox.Checked = bool.Parse(a[c++]);
                CalcParentageBox.Checked = bool.Parse(a[c++]);
                CalcAMOVABox.Checked = bool.Parse(a[c++]);
                CalcStructureBox.Checked = bool.Parse(a[c++]);
                CalcBayesAssBox.Checked = bool.Parse(a[c++]);

                //GLOBAL
                GlobalDecimalPlaceBox.Value = decimal.Parse(a[c++]);
                GlobalThreadBox.Value = decimal.Parse(a[c++]);
                GlobalSeedBox.Text = a[c++];
                GlobalRefreshSeedBox.Checked = bool.Parse(a[c++]);
                GlobalWarningBox.Checked = bool.Parse(a[c++]);
                GlobalFoldControlBox.Checked = bool.Parse(a[c++]);

                //Simulation
                SimPop_AlleleFrequencyBox.Text = a[c++];
                SimPop_FstTerminalBox.Text = a[c++];
                SimPop_DioeciousBox.Checked = bool.Parse(a[c++]);
                SimPop_FemaleRateBox.Value = decimal.Parse(a[c++]);
                SimPop_SelfingRateBox.Value = decimal.Parse(a[c++]);
                SimPop_NegPCRBox.Value = decimal.Parse(a[c++]);
                SimPop_OutputGenotypeBox.Checked = bool.Parse(a[c++]);
                SimPop_SamplingRateBox.Value = decimal.Parse(a[c++]);
                SimPop_DistBox.Text = a[c++];

                //Input
                PhenotypeBox.Text = a[c++];
                FormatBox.SelectedIndex = int.Parse(a[c++]);

                //Allele frequency
                FrequencyRemoveDupAlleleBox.Checked = bool.Parse(a[c++]);
                FrequencyNullAlleleBox.Checked = bool.Parse(a[c++]);
                FrequencyNegPCRBox.Checked = bool.Parse(a[c++]);
                FrequencySelfingBox.Checked = bool.Parse(a[c++]);
                FrequencySelfingRateEstimatorBox.SelectedIndex = int.Parse(a[c++]);
                FrequencyInheritanceModeBox.SelectedIndex = int.Parse(a[c++]);
                FrequencyNrRateBox.Value = decimal.Parse(a[c++]);
                FrequencyResBox.Text = a[c++];

                //Diversity
                DiversityResBox.Text = a[c++];

                //NE
                NeNomura2008Box.Checked = bool.Parse(a[c++]);
                NePudovkin1996Box.Checked = bool.Parse(a[c++]);
                NeWaples2010Box.Checked = bool.Parse(a[c++]);
                NeWaplesMSBox.SelectedIndex = int.Parse(a[c++]);
                NeWaplesFBox.Value = decimal.Parse(a[c++]);


                //Equilibrium
                PhenotypeTestTotBox.Checked = bool.Parse(a[c++]);
                PhenotypeTestRegBox.Checked = bool.Parse(a[c++]);
                PhenotypeTestPopBox.Checked = bool.Parse(a[c++]);
                DistributionResBox.Text = a[c++];

                //Linkage diseq
                LinkageTestTotBox.Checked = bool.Parse(a[c++]);
                LinkageTestRegBox.Checked = bool.Parse(a[c++]);
                LinkageTestPopBox.Checked = bool.Parse(a[c++]);
                LinkageFisherTestBox.Checked = bool.Parse(a[c++]);
                LinkageBurrowsTestBox.Checked = bool.Parse(a[c++]);
                LinkageRaymondTestBox.Checked = bool.Parse(a[c++]);
                LinkageBurninBox.Value = decimal.Parse(a[c++]);
                LinkageBatchesBox.Value = decimal.Parse(a[c++]);
                LinkageIterationsBox.Value = decimal.Parse(a[c++]);
                LinkageResBox.Text = a[c++];

                //Genetic diff
                DiffPopBox.Checked = bool.Parse(a[c++]);
                DiffRegBox.Checked = bool.Parse(a[c++]);
                DiffTotBox.Checked = bool.Parse(a[c++]);
                DiffHuang2018IAMBox.Checked = bool.Parse(a[c++]);
                DiffHuang2018SMMBox.Checked = bool.Parse(a[c++]);
                DiffSlatkin1995Box.Checked = bool.Parse(a[c++]);
                DiffNei1973Box.Checked = bool.Parse(a[c++]);
                DiffHudson1992Box.Checked = bool.Parse(a[c++]);
                DiffHedrick2005Box.Checked = bool.Parse(a[c++]);
                DiffJost2008Box.Checked = bool.Parse(a[c++]);
                DiffHuang2019Box.Checked = bool.Parse(a[c++]);
                DiffTestPhenoBox.Checked = bool.Parse(a[c++]);
                DiffTestAlleleBox.Checked = bool.Parse(a[c++]);
                DiffTestPermBox.Checked = bool.Parse(a[c++]);
                DiffBurninBox.Value = decimal.Parse(a[c++]);
                DiffBatchesBox.Value = decimal.Parse(a[c++]);
                DiffIterationsBox.Value = decimal.Parse(a[c++]);
                DiffResBox.Text = a[c++];

                //Genetic dist
                DistIndBox.Checked = bool.Parse(a[c++]);
                DistPopBox.Checked = bool.Parse(a[c++]);
                DistRegBox.Checked = bool.Parse(a[c++]);
                DistNei1972Box.Checked = bool.Parse(a[c++]);
                DistCavalli1967Box.Checked = bool.Parse(a[c++]);
                DistReynold1993Box.Checked = bool.Parse(a[c++]);
                DistNei1983Box.Checked = bool.Parse(a[c++]);
                DistEuclideanBox.Checked = bool.Parse(a[c++]);
                DistGoldstein1995Box.Checked = bool.Parse(a[c++]);
                DistNei1973Box.Checked = bool.Parse(a[c++]);
                DistRogers1973Box.Checked = bool.Parse(a[c++]);
                DistSokal1958Box.Checked = bool.Parse(a[c++]);
                DistRogers1960Box.Checked = bool.Parse(a[c++]);
                DistJaccard1901Box.Checked = bool.Parse(a[c++]);
                DistSorensen1948Box.Checked = bool.Parse(a[c++]);
                DistSokal1963Box.Checked = bool.Parse(a[c++]);
                DistRussel1940Box.Checked = bool.Parse(a[c++]);
                DistReynolds1983Box.Checked = bool.Parse(a[c++]);
                DistSlatkinBox.Checked = bool.Parse(a[c++]);
                DistResBox.Text = a[c++];

                //Ordination
                OrdinationDimBox.Value = decimal.Parse(a[c++]);
                OrdinationPCoABox.Checked = bool.Parse(a[c++]);
                OrdinationPCABox.Checked = bool.Parse(a[c++]);
                OrdinationFontSizeBox.Text = a[c++];
                OrdinationStyleBox.SelectedIndex = int.Parse(a[c++]);
                OrdinationMarkerSizeBox.Text = a[c++];
                OrdinationMarkerBox.Text = a[c++];
                OrdinationAxesBox.Text = a[c++];
                OrdinationResBox.Text = a[c++];
                string[] str = a[c++].Split(new string[] { IDENTIFIER2 }, StringSplitOptions.None);
                int cp = 1;
                List<POP.ORDINATION> tpcoas = new List<POP.ORDINATION>();
                while (cp < str.Length)
                {
                    POP.ORDINATION tpcoa = new POP.ORDINATION();
                    tpcoa.title = str[cp++];
                    tpcoa.n = int.Parse(str[cp++]);
                    tpcoa.maxp = int.Parse(str[cp++]);
                    tpcoa.names = new string[tpcoa.n];
                    tpcoa.color = new int[tpcoa.n];
                    tpcoa.variance = new double[tpcoa.maxp];
                    tpcoa.coordinate = new double[tpcoa.n, tpcoa.maxp];
                    for (int i = 0; i < tpcoa.n; ++i)
                    {
                        tpcoa.names[i] = str[cp++];
                        tpcoa.color[i] = int.Parse(str[cp++]);
                    }
                    for (int i = 0; i < tpcoa.n; ++i)
                        for (int j = 0; j < tpcoa.maxp; ++j)
                            tpcoa.coordinate[i, j] = double.Parse(str[cp++]);
                    tpcoas.Add(tpcoa);
                }

                if (tpcoas.Count > 0)
                {
                    OrdinationComboBox.Tag = tpcoas;
                    OrdinationComboBox.Items.Clear();
                    OrdinationComboBox.Items.AddRange(tpcoas.Select(d => d.title).ToArray());
                }

                //Hierarchical clustering
                ClusteringNearestBox.Checked = bool.Parse(a[c++]);
                ClusteringFurthestBox.Checked = bool.Parse(a[c++]);
                ClusteringUPGMABox.Checked = bool.Parse(a[c++]);
                ClusteringUPGMCBox.Checked = bool.Parse(a[c++]);
                ClusteringWPGMABox.Checked = bool.Parse(a[c++]);
                ClusteringWPGMCBox.Checked = bool.Parse(a[c++]);
                ClusteringWARDBox.Checked = bool.Parse(a[c++]);
                ClusteringFontSizeBox.Text = a[c++];
                ClusteringLineSepBox.Text = a[c++];

                ClusteringResBox.Text = a[c++];
                string[] str2 = a[c++].Split(new string[] { IDENTIFIER2 }, StringSplitOptions.RemoveEmptyEntries);
                if (str2.Length > 0)
                {
                    ClusteringComboBox.Items.Clear();
                    ClusteringComboBox.Tag = str2.ToList();
                    ClusteringComboBox.Items.AddRange(str2.Select(s => s.Substring(0, s.IndexOf(':'))).ToArray());
                }

                //Individual inbreeding
                InbreedingRitland1996Box.Checked = bool.Parse(a[c++]);
                InbreedingLoiselle1995Box.Checked = bool.Parse(a[c++]);
                InbreedingWeir1996Box.Checked = bool.Parse(a[c++]);
                InbreedingHuangUnpubBox.Checked = bool.Parse(a[c++]);
                InbreedingJackknifeBox.Checked = bool.Parse(a[c++]);
                InbreedingResBox.Text = a[c++];

                //Individual Hindex
                HIndexResBox.Text = a[c++];

                //Population assignment
                AssignmentErrorBox.Value = decimal.Parse(a[c++]);
                AssignmentPloidyBox.Checked = bool.Parse(a[c++]);
                AssignmentResBox.Text = a[c++];

                //Spatial pattern
                SpatialDistClassBox.SelectedIndex = int.Parse(a[c++]);
                SpatialDistIntervalBox.Text = a[c++];
                SpatialHaversineBox.Checked = bool.Parse(a[c++]);
                SpatialJackknifeBox.Checked = bool.Parse(a[c++]);

                //Relationship
                RelationshipPopBox.Checked = bool.Parse(a[c++]);
                RelationshipRegBox.Checked = bool.Parse(a[c++]);
                RelationshipTotBox.Checked = bool.Parse(a[c++]);
                RelationshipHuang2014Box.Checked = bool.Parse(a[c++]);
                RelationshipHuang2015Box.Checked = bool.Parse(a[c++]);
                RelationshipRitland1996mBox.Checked = bool.Parse(a[c++]);
                RelationshipRitland1996Box.Checked = bool.Parse(a[c++]);
                RelationshipLoiselle1995mBox.Checked = bool.Parse(a[c++]);
                RelationshipLoiselle1995Box.Checked = bool.Parse(a[c++]);
                RelationshipHardy1999Box.Checked = bool.Parse(a[c++]);
                RelationshipWeir1996Box.Checked = bool.Parse(a[c++]);
                RelationshipHuangUnpubmBox.Checked = bool.Parse(a[c++]);
                RelationshipHuangUnpubBox.Checked = bool.Parse(a[c++]);
                RelationshipJackknifeBox.Checked = bool.Parse(a[c++]);
                RelationshipResBox.Text = a[c++];

                //Heritability
                HeritabilityRitland1996Box.Checked = bool.Parse(a[c++]);
                HeritabilityMousseau1998Box.Checked = bool.Parse(a[c++]);
                HeritabilityThomas2000Box.Checked = bool.Parse(a[c++]);
                HeritabilityHuangMLBox.Checked = bool.Parse(a[c++]);
                HeritabilityHuangMOMBox.Checked = bool.Parse(a[c++]);
                HeritabilityJackknifeBox.Checked = bool.Parse(a[c++]);

                //Parentage analysis
                ParentagePaternityBox.Checked = bool.Parse(a[c++]);
                ParentageParentPairBox.Checked = bool.Parse(a[c++]);
                ParentageUnknownBox.Checked = bool.Parse(a[c++]);
                ParentageSamplingRateBox.Value = decimal.Parse(a[c++]);
                ParentageMistypeRateBox.Value = decimal.Parse(a[c++]);
                ParentageNSimBox.Value = decimal.Parse(a[c++]);
                ParentagePaternityNFatherBox.Value = decimal.Parse(a[c++]);
                ParentageParentPairNFatherBox.Value = decimal.Parse(a[c++]);
                ParentageParentPairNMotherBox.Value = decimal.Parse(a[c++]);
                ParentageErrorNSimBox.Value = decimal.Parse(a[c++]);
                ParentageUnknownNCandidateBox.Value = decimal.Parse(a[c++]);
                ParentageOutputBox.SelectedIndex = int.Parse(a[c++]);
                ParentageMethodBox.SelectedIndex = int.Parse(a[c++]);
                ParentageSkipSimBox.Checked = bool.Parse(a[c++]);
                D2_999.Value = decimal.Parse(a[c++]);
                D2_99.Value = decimal.Parse(a[c++]);
                D2_95.Value = decimal.Parse(a[c++]);
                D2_80.Value = decimal.Parse(a[c++]);
                D1_999.Value = decimal.Parse(a[c++]);
                D1_99.Value = decimal.Parse(a[c++]);
                D1_95.Value = decimal.Parse(a[c++]);
                D1_80.Value = decimal.Parse(a[c++]);
                DPM_999.Value = decimal.Parse(a[c++]);
                DPM_99.Value = decimal.Parse(a[c++]);
                DPM_95.Value = decimal.Parse(a[c++]);
                DPM_80.Value = decimal.Parse(a[c++]);
                DPF_999.Value = decimal.Parse(a[c++]);
                DPF_99.Value = decimal.Parse(a[c++]);
                DPF_95.Value = decimal.Parse(a[c++]);
                DPF_80.Value = decimal.Parse(a[c++]);
                DP_999.Value = decimal.Parse(a[c++]);
                DP_99.Value = decimal.Parse(a[c++]);
                DP_95.Value = decimal.Parse(a[c++]);
                DP_80.Value = decimal.Parse(a[c++]);
                DPU_999.Value = decimal.Parse(a[c++]);
                DPU_99.Value = decimal.Parse(a[c++]);
                DPU_95.Value = decimal.Parse(a[c++]);
                DPU_80.Value = decimal.Parse(a[c++]);
                ParentageSimResBox.Text = a[c++];
                ParentagePaternityOffspringBox.Text = a[c++];
                ParentagePaternityResBox.Text = a[c++];
                ParentageParentPairOffspringBox.Text = a[c++];
                ParentageParentPairMotherBox.Text = a[c++];
                ParentageParentPairFatherBox.Text = a[c++];
                ParentageParentPairResBox.Text = a[c++];
                ParentageUnknownOffspringBox.Text = a[c++];
                ParentageUnknownParentBox.Text = a[c++];
                ParentageUnknownResBox.Text = a[c++];
                ParentageErrorResBox.Text = a[c++];
                ParentageSampleResBox.Text = a[c++];
                ParentageEstErrorBox.SelectedIndex = int.Parse(a[c++]);
                ParentageEstSampleBox.Checked = bool.Parse(a[c++]);
                ParentageRedoBox.Checked = bool.Parse(a[c++]);

                //AMOVA
                AMOVAIAMBox.Checked = bool.Parse(a[c++]);
                AMOVASMMBox.Checked = bool.Parse(a[c++]);
                AMOVAIgnoreIndBox.Checked = bool.Parse(a[c++]);
                AMOVAOutputSSBox.Checked = bool.Parse(a[c++]);
                AMOVANPermBox.Value = decimal.Parse(a[c++]);
                AMOVAHomoBox.Checked = bool.Parse(a[c++]);
                AMOVAHomoCorrBox.Checked = bool.Parse(a[c++]);
                AMOVAAnisoBox.Checked = bool.Parse(a[c++]);
                AMOVAGenotypeBox.Checked = bool.Parse(a[c++]);
                AMOVAMLBox.Checked = bool.Parse(a[c++]);
                GlobalRegionBox.Text = a[c++];
                AMOVAResBox.Text = a[c++];

                //Structure
                StructureADMBox.Checked = bool.Parse(a[c++]);
                StructureLOCPRIORIBox.Checked = bool.Parse(a[c++]);
                StructureFmodelBox.Checked = bool.Parse(a[c++]);
                StructureKminBox.Value = decimal.Parse(a[c++]);
                StructureKmaxBox.Value = decimal.Parse(a[c++]);

                StructureBurninBox.Value = decimal.Parse(a[c++]);
                StructureNRepsBox.Value = decimal.Parse(a[c++]);
                StructureNThinningBox.Value = decimal.Parse(a[c++]);
                StructureNRunsBox.Value = decimal.Parse(a[c++]);

                StructureLambdaBox.Value = decimal.Parse(a[c++]);
                StructureStdLambdaBox.Value = decimal.Parse(a[c++]);
                StructureMaxLambdaBox.Value = decimal.Parse(a[c++]);
                StructureADMBurninBox.Value = decimal.Parse(a[c++]);
                StructureInferLambdaBox.Checked = bool.Parse(a[c++]);
                StructureDiffLambdaBox.Checked = bool.Parse(a[c++]);

                StructureAlpha0Box.Value = decimal.Parse(a[c++]);
                StructureStdAlphaBox.Value = decimal.Parse(a[c++]);
                StructureMaxAlphaBox.Value = decimal.Parse(a[c++]);
                StructureUpdateQBox.Value = decimal.Parse(a[c++]);
                StructureInferAlphaBox.Checked = bool.Parse(a[c++]);
                StructureDiffAlphaBox.Checked = bool.Parse(a[c++]);
                StructureUniformAlphaBox.Checked = bool.Parse(a[c++]);
                StructureAlphaPrioriABox.Value = decimal.Parse(a[c++]);
                StructureAlphaPrioriBBox.Value = decimal.Parse(a[c++]);

                StructureMaxRBox.Value = decimal.Parse(a[c++]);
                StructureEpsRBox.Value = decimal.Parse(a[c++]);
                StructureEpsEtaBox.Value = decimal.Parse(a[c++]);
                StructureEpsGammaBox.Value = decimal.Parse(a[c++]);

                StructureFPriorMeanBox.Value = decimal.Parse(a[c++]);
                StructureFPriorStdBox.Value = decimal.Parse(a[c++]);
                StructureFStdFBox.Value = decimal.Parse(a[c++]);
                StructureFSameBox.Checked = bool.Parse(a[c++]);

                StructureIndividualOrderBox.SelectedIndex = int.Parse(a[c++]);
                StructureRearrangeColorBox.SelectedIndex = int.Parse(a[c++]);
                StructureRunDetailBox.Text = a[c++];

                BayesAssMethodBox.SelectedIndex = int.Parse(a[c++]);
                BayesAssBurninBox.Value = decimal.Parse(a[c++]);
                BayesAssNRepsBox.Value = decimal.Parse(a[c++]);
                BayesAssNThinningBox.Value = decimal.Parse(a[c++]);
                BayesAssNRunsBox.Value = decimal.Parse(a[c++]);
                BayesAssDeltaABox.Value = decimal.Parse(a[c++]);
                BayesAssDeltaFBox.Value = decimal.Parse(a[c++]);
                BayesAssDeltaMBox.Value = decimal.Parse(a[c++]);
                BayesAssPlotStyleBox.SelectedIndex = int.Parse(a[c++]);

                //Mantel
                MantelNPermBox.Value = decimal.Parse(a[c++]);
                MantelResBox.Text = a[c++];
                MantelMatBox.Text = a[c++];

                //Form1
                ImportFileDialog.FileName = a[c++];
                SavePicDialog.FileName = a[c++];
                SaveDataDialog.FileName = a[c++];

                //Form3
                f3.PloidyBox.Value = int.Parse(a[c++]);
                f3.MissingBox.Value = int.Parse(a[c++]);
                f3.FirstRowBox.Checked = bool.Parse(a[c++]);
                f3.SecondColumnBox.Checked = bool.Parse(a[c++]);
                f3.PhaseBox.Checked = bool.Parse(a[c++]);
                f3.SingleRowBox.Checked = bool.Parse(a[c++]);
                f3.FileBox.Text = a[c++];
                f3.ImportFileDialog.FileName = a[c++];

                //Form4
                f4.dr0.Checked = bool.Parse(a[c++]);
                f4.dr1.Checked = bool.Parse(a[c++]);
                f4.dr2.Checked = bool.Parse(a[c++]);
                f4.dr3.Checked = bool.Parse(a[c++]);
                f4.dr4.Checked = bool.Parse(a[c++]);
                f4.dr5.Checked = bool.Parse(a[c++]);
                f4.self0.Checked = bool.Parse(a[c++]);
                f4.self1.Checked = bool.Parse(a[c++]);
                f4.self2.Checked = bool.Parse(a[c++]);
                f4.self3.Checked = bool.Parse(a[c++]);
                f4.py0.Checked = bool.Parse(a[c++]);
                f4.py1.Checked = bool.Parse(a[c++]);
                f4.beta0.Checked = bool.Parse(a[c++]);
                f4.beta1.Checked = bool.Parse(a[c++]);

                //Form5
                f5.MethodBox.SelectedIndex = int.Parse(a[c++]);
                f5.FormatBox.SelectedIndex = int.Parse(a[c++]);
                f5.FillMissingBox.SelectedIndex = int.Parse(a[c++]);
                f5.RepeatBox.Value = int.Parse(a[c++]);
                f5.NFileBox.Value = int.Parse(a[c++]);
                f5.NullBox.Value = int.Parse(a[c++]);
                f5.MaxNBox.Value = int.Parse(a[c++]);
                f5.DirBox.Text = a[c++];
                f5.ExportFolderDialog.SelectedPath = a[c++];

                //Form6
                f6.OutputStyleBox.SelectedIndex = int.Parse(a[c++]);
                f6.NAlleleBox1.Value = decimal.Parse(a[c++]);
                f6.NAlleleBox2.Value = decimal.Parse(a[c++]);
                f6.FilterBox.Text = a[c++];
                f6.QualBox.Value = decimal.Parse(a[c++]);
                f6.HeBox.Value = decimal.Parse(a[c++]);
                f6.GenotypeRateBox.Value = decimal.Parse(a[c++]);
                f6.MAFBox.Value = decimal.Parse(a[c++]);
                f6.WindowSizeBox.Value = decimal.Parse(a[c++]);
                f6.GQBox.Value = decimal.Parse(a[c++]);
                f6.DPBox.Value = decimal.Parse(a[c++]);
                f6.FileBox.Text = a[c++];
                f6.ImportFileDialog.FileName = a[c++];
            }
            catch
            {

            }
        }

        private void ApplySettings()
        {
            // Apply configurations and set UI controls

            if (runstate == GlobalRunState.mantelrunning || runstate == GlobalRunState.running || runstate == GlobalRunState.simulating) return;

            CALC_DISTRIBUTION = CalcDistributionBox.Checked;
            CALC_LINKAGE = CalcLinkageBox.Checked;
            CALC_NE = CalcNeBox.Checked;
            CALC_DIFF = CalcDiffBox.Checked;
            CALC_DIST = CalcDistBox.Checked;
            CALC_ORDINATION = CalcOrdinationBox.Checked;
            CALC_CLUSTERING = CalcClusteringBox.Checked;
            CALC_INBREEDING = CalcInbreedingBox.Checked;
            CALC_HINDEX = CalcHIndexBox.Checked;
            CALC_ASSIGNMENT = CalcAssignmentBox.Checked;
            CALC_SPATIAL = CalcSpatialBox.Checked;
            CALC_RELATIONSHIP = CalcRelationshipBox.Checked;
            CALC_HERITABILITY = CalcHeritabilityBox.Checked;
            CALC_QST = CalcQstBox.Checked;
            CALC_PARENTAGE = CalcParentageBox.Checked;
            CALC_AMOVA = CalcAMOVABox.Checked;
            CALC_STRUCTURE = CalcStructureBox.Checked;
            CALC_BAYESASS = CalcBayesAssBox.Checked;

            //GLOBAL
            PHENOTYPE_INPUT = PhenotypeBox.Text;
            FORMAT = (InputFormat)FormatBox.SelectedIndex;
            DECIMAL = "F" + ((int)GlobalDecimalPlaceBox.Value);
            N_THREAD = (int)GlobalThreadBox.Value;
            SEED = int.Parse(GlobalSeedBox.Text);
            SEED_REFRESH = GlobalRefreshSeedBox.Checked;
            REMIND_WARNING = GlobalWarningBox.Checked;
            FOLD_CONTROL = GlobalFoldControlBox.Checked;

            //Simulation
            SIMPOP_FST_TERMINAL = double.Parse(SimPop_FstTerminalBox.Text);
            SIMPOP_DIOECIOUS = SimPop_DioeciousBox.Checked;
            SIMPOP_FEMALE_RATE = (double)SimPop_FemaleRateBox.Value;
            SIMPOP_SELFING_RATIO = (double)SimPop_SelfingRateBox.Value;
            SIMPOP_BETA_RATIO = (double)SimPop_NegPCRBox.Value;
            SIMPOP_SAMPLING_RATIO = (double)SimPop_SamplingRateBox.Value;
            SIMPOP_OUTPUT_GENOTYPE = SimPop_OutputGenotypeBox.Checked;
            SIMPOP_DIST = SimPop_DistBox.Text;

            //Allele freqeuncy
            REMOVE_DUP_ALLELE = FrequencyRemoveDupAlleleBox.Checked;
            CONSIDER_NULL = FrequencyNullAlleleBox.Checked;
            CONSIDER_NEGATIVE = FrequencyNegPCRBox.Checked;
            CONSIDER_SELFING = FrequencySelfingBox.Checked && DR_MODE != DoubleReductionModel.PESRS;
            DISCARD_EMPTY = ISGENOTYPE || (!CONSIDER_NULL && !CONSIDER_NEGATIVE && !ISGENOTYPE);
            SELFING_ESTIMATOR = (SelfingRateEstimator)FrequencySelfingRateEstimatorBox.SelectedIndex;
            DR_MODE = (DoubleReductionModel)FrequencyInheritanceModeBox.SelectedIndex;
            NRRATE = (double)FrequencyNrRateBox.Value;

            //Diversity

            //NE
            NE_NOMURA2008 = NeNomura2008Box.Checked;
            NE_PUDOVKIN2009 = NePudovkin1996Box.Checked;
            NE_WAPLES2010 = NeWaples2010Box.Checked;
            NE_WAPLES_MS = (WaplesMatingSystem)NeWaplesMSBox.SelectedIndex;
            NE_WAPLES_F = (double)NeWaplesFBox.Value;

            //Equilibrium
            DISTRIBUTION_TOT = PhenotypeTestTotBox.Checked;
            DISTRIBUTION_REG = PhenotypeTestRegBox.Checked;
            DISTRIBUTION_POP = PhenotypeTestPopBox.Checked;

            //Linkage Disteq
            LINKAGE_TOT = LinkageTestTotBox.Checked;
            LINKAGE_REG = LinkageTestRegBox.Checked;
            LINKAGE_POP = LinkageTestPopBox.Checked;
            LINKAGE_FISHER = LinkageFisherTestBox.Checked;
            LINKAGE_BURROWS = LinkageBurrowsTestBox.Checked;
            LINKAGE_RAYMOND = LinkageRaymondTestBox.Checked;
            LINKAGE_BURNIN = (int)LinkageBurninBox.Value;
            LINKAGE_BATCHES = (int)LinkageBatchesBox.Value;
            LINKAGE_ITERATIONS = (int)LinkageIterationsBox.Value;

            //Genetic diff
            DIFF_POP = DiffPopBox.Checked;
            DIFF_REG = DiffRegBox.Checked;
            DIFF_TOT = DiffTotBox.Checked;
            DIFF_Huang2018IAM = DiffHuang2018IAMBox.Checked;
            DIFF_Huang2018SMM = DiffHuang2018SMMBox.Checked;
            DIFF_Slatkin1995 = DiffSlatkin1995Box.Checked;
            DIFF_Nei1973 = DiffNei1973Box.Checked;
            DIFF_Hudson1992 = DiffHudson1992Box.Checked;
            DIFF_Hedrick2005 = DiffHedrick2005Box.Checked;
            DIFF_Jost2008 = DiffJost2008Box.Checked;
            DIFF_Huang2019 = DiffHuang2019Box.Checked;
            DIFF_TESTPHENO = DiffTestPhenoBox.Checked;
            DIFF_TESTALLELE = DiffTestAlleleBox.Checked;
            DIFF_TESTPERM = DiffTestPermBox.Checked;
            DIFF_BURNIN = (int)DiffBurninBox.Value;
            DIFF_BATCHES = (int)DiffBatchesBox.Value;
            DIFF_ITERATIONS = (int)DiffIterationsBox.Value;

            //Genetic dist
            DIST_IND = DistIndBox.Checked;
            DIST_POP = DistPopBox.Checked;
            DIST_REG = DistRegBox.Checked;
            DIST_Nei1972 = DistNei1972Box.Checked;
            DIST_Cavalli1967 = DistCavalli1967Box.Checked;
            DIST_Reynold1993 = DistReynold1993Box.Checked;
            DIST_Nei1983 = DistNei1983Box.Checked;
            DIST_Euclidean = DistEuclideanBox.Checked;
            DIST_Goldstein1995 = DistGoldstein1995Box.Checked;
            DIST_Nei1973 = DistNei1973Box.Checked;
            DIST_Rogers1973 = DistRogers1973Box.Checked;
            DIST_Sokal1958 = DistSokal1958Box.Checked;
            DIST_Rogers1960 = DistRogers1960Box.Checked;
            DIST_Jaccard1901 = DistJaccard1901Box.Checked;
            DIST_Sorensen1948 = DistSorensen1948Box.Checked;
            DIST_Sokal1963 = DistSokal1963Box.Checked;
            DIST_Russel1940 = DistRussel1940Box.Checked;
            DIST_Reynolds1983 = DistReynolds1983Box.Checked;
            DIST_Slatkin1995 = DistSlatkinBox.Checked;

            //Ordination
            ORDINATION_NDIM = (int)OrdinationDimBox.Value;
            ORDINATION_PCOA = OrdinationPCoABox.Checked;
            ORDINATION_PCA = OrdinationPCABox.Checked;
            ORDINATION_FONT_SIZE = int.Parse(OrdinationFontSizeBox.Text);
            ORDINATION_STYLE = OrdinationStyleBox.SelectedIndex < 0 ? 0 : OrdinationStyleBox.SelectedIndex;
            ORDINATION_MARKER_SIZE = int.Parse(OrdinationMarkerSizeBox.Text);
            ORDINATION_MARKER = OrdinationMarkerBox.Text;
            ORDINATION_AXES = OrdinationAxesBox.Text;

            //Hierarchicalclustering
            CLUSTERING_NEAREST = ClusteringNearestBox.Checked;
            CLUSTERING_FURTHEST = ClusteringFurthestBox.Checked;
            CLUSTERING_UPGMA = ClusteringUPGMABox.Checked;
            CLUSTERING_UPGMC = ClusteringUPGMCBox.Checked;
            CLUSTERING_WPGMA = ClusteringWPGMABox.Checked;
            CLUSTERING_WPGMC = ClusteringWPGMCBox.Checked;
            CLUSTERING_WARD = ClusteringWARDBox.Checked;
            CLUSTERING_FONT_SIZE = int.Parse(ClusteringFontSizeBox.Text);
            CLUSTERING_LINE_SEP = int.Parse(ClusteringLineSepBox.Text);

            //Individualinbreeding
            INBREEDING_Ritland1996 = InbreedingRitland1996Box.Checked;
            INBREEDING_Loiselle1995 = InbreedingLoiselle1995Box.Checked;
            INBREEDING_Weir1996 = InbreedingWeir1996Box.Checked;
            INBREEDING_HuangUnpub = InbreedingHuangUnpubBox.Checked;
            INBREEDING_JACKKNIFE = InbreedingJackknifeBox.Checked;

            //Individual H index

            //Population Assignment
            ASSIGNMENT_ERROR = (double)AssignmentErrorBox.Value;
            ASSIGNMENT_PLOIDY = AssignmentPloidyBox.Checked;

            //Spatial
            SPATIAL_DISTCLASS = SpatialDistClassBox.SelectedIndex;
            SPATIAL_DISTINTERVAL = SpatialDistIntervalBox.Text;
            SPATIAL_HAVERSINE = SpatialHaversineBox.Checked;
            SPATIAL_JACKKNIFE = SpatialJackknifeBox.Checked;

            //Relationship
            RELATIONSHIP_POP = RelationshipPopBox.Checked;
            RELATIONSHIP_REG = RelationshipRegBox.Checked;
            RELATIONSHIP_TOT = RelationshipTotBox.Checked;
            RELATIONSHIP_Huang2014 = RelationshipHuang2014Box.Checked;
            RELATIONSHIP_Huang2015 = RelationshipHuang2015Box.Checked;
            RELATIONSHIP_Ritland1996m = RelationshipRitland1996mBox.Checked;
            RELATIONSHIP_Ritland1996 = RelationshipRitland1996Box.Checked;
            RELATIONSHIP_Loiselle1995m = RelationshipLoiselle1995mBox.Checked;
            RELATIONSHIP_Loiselle1995 = RelationshipLoiselle1995Box.Checked;
            RELATIONSHIP_Hardy1999 = RelationshipHardy1999Box.Checked;
            RELATIONSHIP_Weir1996 = RelationshipWeir1996Box.Checked;
            RELATIONSHIP_HuangUnpubm = RelationshipHuangUnpubmBox.Checked;
            RELATIONSHIP_HuangUnpub = RelationshipHuangUnpubBox.Checked;
            RELATIONSHIP_JACKKNIFE = RelationshipJackknifeBox.Checked;

            //Heritability
            HERITABILITY_Ritland1996 = HeritabilityRitland1996Box.Checked;
            HERITABILITY_Mousseau1998 = HeritabilityMousseau1998Box.Checked;
            HERITABILITY_Thomas2000 = HeritabilityThomas2000Box.Checked;
            HERITABILITY_HuangML = HeritabilityHuangMLBox.Checked;
            HERITABILITY_HuangMOM = HeritabilityHuangMOMBox.Checked;
            HERITABILITY_Jackknife = HeritabilityJackknifeBox.Checked;

            //Parentage analysis
            PARENTAGE_PATERNITY = ParentagePaternityBox.Checked;
            PARENTAGE_PARENTPAIR = ParentageParentPairBox.Checked;
            PARENTAGE_UNKNOWN = ParentageUnknownBox.Checked;
            PARENTAGE_SAMPLING_RATE = (double)ParentageSamplingRateBox.Value;
            PARENTAGE_MISTYPE_RATE = (double)ParentageMistypeRateBox.Value;
            PARENTAGE_NSIM = (int)ParentageNSimBox.Value;
            PARENTAGE_PATERNITY_NFATHER = (int)ParentagePaternityNFatherBox.Value;
            PARENTAGE_PARENTPAIR_NFATHER = (int)ParentageParentPairNFatherBox.Value;
            PARENTAGE_PARENTPAIR_NMOTHER = (int)ParentageParentPairNMotherBox.Value;
            PARENTAGE_ERROR_NSIM = (int)ParentageErrorNSimBox.Value;
            PARENTAGE_UNKNOWN_NCANDIDATE = (int)ParentageUnknownNCandidateBox.Value;
            PARENTAGE_OUTPUT = (ParentageOutputStyle)ParentageOutputBox.SelectedIndex;
            PARENTAGE_METHOD = (ParentageMethod)ParentageMethodBox.SelectedIndex;
            PARENTAGE_SKIPSIM = ParentageSkipSimBox.Checked;
            PARENTAGE_ESTERR = (ParentageEstimateError)ParentageEstErrorBox.SelectedIndex;
            PARENTAGE_ESTSR = ParentageEstSampleBox.Checked;
            PARENTAGE_REDO = ParentageRedoBox.Checked;

            d2_999 = (double)D2_999.Value;
            d2_99 = (double)D2_99.Value;
            d2_95 = (double)D2_95.Value;
            d2_80 = (double)D2_80.Value;
            d1_999 = (double)D1_999.Value;
            d1_99 = (double)D1_99.Value;
            d1_95 = (double)D1_95.Value;
            d1_80 = (double)D1_80.Value;
            dPM_999 = (double)DPM_999.Value;
            dPM_99 = (double)DPM_99.Value;
            dPM_95 = (double)DPM_95.Value;
            dPM_80 = (double)DPM_80.Value;
            dPF_999 = (double)DPF_999.Value;
            dPF_99 = (double)DPF_99.Value;
            dPF_95 = (double)DPF_95.Value;
            dPF_80 = (double)DPF_80.Value;
            dP_999 = (double)DP_999.Value;
            dP_99 = (double)DP_99.Value;
            dP_95 = (double)DP_95.Value;
            dP_80 = (double)DP_80.Value;
            dPU_999 = (double)DPU_999.Value;
            dPU_99 = (double)DPU_99.Value;
            dPU_95 = (double)DPU_95.Value;
            dPU_80 = (double)DPU_80.Value;


            //AMOVA
            AMOVA_IAM = AMOVAIAMBox.Checked;
            AMOVA_SMM = AMOVASMMBox.Checked;
            AMOVA_IGNOREIND = AMOVAIgnoreIndBox.Checked;
            AMOVA_OUTPUTSS = AMOVAOutputSSBox.Checked;
            AMOVA_PERMUTE = (int)AMOVANPermBox.Value;
            REGIONTEXT = GlobalRegionBox.Text;
            AMOVA_HOMO = AMOVAHomoBox.Checked;
            AMOVA_HOMO_CORR = AMOVAHomoCorrBox.Checked;
            AMOVA_ANISO = AMOVAAnisoBox.Checked;
            AMOVA_GENO = AMOVAGenotypeBox.Checked;
            AMOVA_ML = AMOVAMLBox.Checked;

            //Structure
            STRUCTURE_ADMIXTURE = StructureADMBox.Checked;
            STRUCTURE_LOCPRIORI = StructureLOCPRIORIBox.Checked;
            STRUCTURE_FMODEL = StructureFmodelBox.Checked;
            STRUCTURE_KMIN = Math.Min((int)StructureKminBox.Value, (int)StructureKmaxBox.Value);
            STRUCTURE_KMAX = Math.Max((int)StructureKminBox.Value, (int)StructureKmaxBox.Value);

            STRUCTURE_NBURNIN = (int)StructureBurninBox.Value;
            STRUCTURE_NREPS = (int)StructureNRepsBox.Value;
            STRUCTURE_NTHINNING = (int)StructureNThinningBox.Value;
            STRUCTURE_NRUNS = (int)StructureNRunsBox.Value;

            STRUCTURE_LAMBDA = (double)StructureLambdaBox.Value;
            STRUCTURE_STDLAMBDA = (double)StructureStdLambdaBox.Value;
            STRUCTURE_MAXLAMBDA = (double)StructureMaxLambdaBox.Value;
            STRUCTURE_ADMBURNIN = (int)StructureADMBurninBox.Value;
            STRUCTURE_INFERLAMBDA = StructureInferLambdaBox.Checked;
            STRUCTURE_DIFFLAMBDA = StructureDiffLambdaBox.Checked;

            STRUCTURE_ALPHA0 = (double)StructureAlpha0Box.Value;
            STRUCTURE_STDALPHA = (double)StructureStdAlphaBox.Value;
            STRUCTURE_MAXALPHA = (double)StructureMaxAlphaBox.Value;
            STRUCTURE_METROFREQ = (int)StructureUpdateQBox.Value;
            STRUCTURE_INFERALPHA = StructureInferAlphaBox.Checked;
            STRUCTURE_DIFFALPHA = StructureDiffAlphaBox.Checked;
            STRUCTURE_GAMMAALPHA = !StructureUniformAlphaBox.Checked;
            STRUCTURE_ALPHAPRIORA = (double)StructureAlphaPrioriABox.Value;
            STRUCTURE_ALPHAPRIORB = (double)StructureAlphaPrioriBBox.Value;

            STRUCTURE_MAXR = (double)StructureMaxRBox.Value;
            STRUCTURE_EPSR = (double)StructureEpsRBox.Value;
            STRUCTURE_EPSETA = (double)StructureEpsEtaBox.Value;
            STRUCTURE_EPSGAMMA = (double)StructureEpsGammaBox.Value;

            STRUCTURE_FPRIORMEAN = (double)StructureFPriorMeanBox.Value;
            STRUCTURE_FPRIORSTD = (double)StructureFPriorStdBox.Value;
            STRUCTURE_FSTDF = (double)StructureFStdFBox.Value;
            STRUCTURE_FSAME = StructureFSameBox.Checked;

            STRUCTURE_STYLE = (StructurePlotType)StructureIndividualOrderBox.SelectedIndex;
            STRUCTURE_REARRANGE = StructureRearrangeColorBox.SelectedIndex == 0;

            //BAYESASS
            BAYESASS_TYPE = (BayesAssType)BayesAssMethodBox.SelectedIndex;
            BAYESASS_NBURNIN = (int)BayesAssBurninBox.Value;
            BAYESASS_NREPS = (int)BayesAssNRepsBox.Value;
            BAYESASS_NTHINNING = (int)BayesAssNThinningBox.Value;
            BAYESASS_NRUNS = (int)BayesAssNRunsBox.Value;
            BAYESASS_NOLIKELIHOOD = BayesAssNoLikelihoodBox.Checked;

            BAYESASS_DELTAA = (double)BayesAssDeltaABox.Value;
            BAYESASS_DELTAF = (double)BayesAssDeltaFBox.Value;
            BAYESASS_DELTAM = (double)BayesAssDeltaMBox.Value;

            BAYESASS_PLOTSTYLE = (BayesAssPlotType)BayesAssPlotStyleBox.SelectedIndex;

            //Mantel
            MANTEL_INPUT = MantelMatBox.Text;
            MANTEL_NPERM = (int)MantelNPermBox.Value;
        }

        private void DefaultSettings(object sender, EventArgs e)
        {
            // Reset default configurations
            GlobalDecimalPlaceBox.Value = 3;
            GlobalThreadBox.Value = 4;
            GlobalRefreshSeedBox.Checked = true;
            GlobalWarningBox.Checked = true;
            GlobalFoldControlBox.Checked = true;

            //Simulation
            SimPop_FemaleRateBox.Value = 0.50m;
            SimPop_SelfingRateBox.Value = 0;
            SimPop_SamplingRateBox.Value = 1;
            SimPop_SelfingRateBox.Value = 0;
            SimPop_OutputGenotypeBox.Checked = false;
            SimPop_DioeciousBox.Checked = false;

            //Frequency
            FrequencyRemoveDupAlleleBox.Checked = true;
            FrequencyNullAlleleBox.Checked = false;
            FrequencyNegPCRBox.Checked = false;
            FrequencySelfingBox.Checked = false;
            FrequencySelfingRateEstimatorBox.SelectedIndex = 0;
            FrequencyInheritanceModeBox.SelectedIndex = 0;
            FrequencyNrRateBox.Value = 0.95m;

            //Diversity

            //Equilibrium
            PhenotypeTestPopBox.Checked = true;
            PhenotypeTestRegBox.Checked = false;
            PhenotypeTestTotBox.Checked = false;

            //Linkage
            LinkageTestTotBox.Checked = false;
            LinkageTestRegBox.Checked = false;
            LinkageTestPopBox.Checked = true;
            LinkageFisherTestBox.Checked = true;
            LinkageBurrowsTestBox.Checked = true;
            LinkageRaymondTestBox.Checked = true;
            LINKAGE_BURNIN = 5000;
            LINKAGE_BATCHES = 100;
            LINKAGE_ITERATIONS = 5000;

            //Ne
            NePudovkin1996Box.Checked = false;
            NeNomura2008Box.Checked = true;
            NeWaples2010Box.Checked = true;
            NeWaplesMSBox.SelectedIndex = 0;
            NeWaplesFBox.Value = 1;

            //Differentation
            DiffPopBox.Checked = true;
            DiffRegBox.Checked = false;
            DiffTotBox.Checked = true;
            DiffHuang2018IAMBox.Checked = true;
            DiffHuang2018SMMBox.Checked = true;
            DiffSlatkin1995Box.Checked = false;
            DiffNei1973Box.Checked = false;
            DiffHudson1992Box.Checked = false;
            DiffHedrick2005Box.Checked = false;
            DiffJost2008Box.Checked = false;
            DiffHuang2019Box.Checked = false;
            DiffTestPhenoBox.Checked = false;
            DiffTestAlleleBox.Checked = false;
            DiffTestPermBox.Checked = false;
            DIFF_BURNIN = 5000;
            DIFF_BATCHES = 100;
            DIFF_ITERATIONS = 5000;

            //Genetic distance
            DistIndBox.Checked = false;
            DistPopBox.Checked = true;
            DistRegBox.Checked = false;
            DistNei1972Box.Checked = true;
            DistCavalli1967Box.Checked = false;
            DistReynold1993Box.Checked = false;
            DistNei1983Box.Checked = false;
            DistEuclideanBox.Checked = false;
            DistGoldstein1995Box.Checked = false;
            DistNei1973Box.Checked = false;
            DistRogers1973Box.Checked = false;
            DistSokal1958Box.Checked = false;
            DistRogers1960Box.Checked = false;
            DistJaccard1901Box.Checked = false;
            DistSorensen1948Box.Checked = false;
            DistSokal1963Box.Checked = false;
            DistRussel1940Box.Checked = false;
            DistReynolds1983Box.Checked = false;
            DistSlatkinBox.Checked = false;

            //PCOA
            OrdinationDimBox.Value = 3;
            OrdinationPCoABox.Checked = false;
            OrdinationPCABox.Checked = false;
            OrdinationFontSizeBox.Text = "12";
            OrdinationStyleBox.SelectedIndex = 0;
            OrdinationMarkerSizeBox.Text = "10";
            OrdinationMarkerBox.Text = "+✕○●△▲□■⬠⬟⬡⬢";
            OrdinationAxesBox.Text = "1,2";

            //Hierarchical clustering
            ClusteringNearestBox.Checked = false;
            ClusteringFurthestBox.Checked = false;
            ClusteringUPGMABox.Checked = false;
            ClusteringWPGMABox.Checked = false;
            ClusteringUPGMCBox.Checked = false;
            ClusteringWPGMCBox.Checked = false;
            ClusteringWARDBox.Checked = true;
            ClusteringFontSizeBox.Text = "12";
            ClusteringLineSepBox.Text = "8";

            //Inbreeding
            InbreedingRitland1996Box.Checked = true;
            InbreedingLoiselle1995Box.Checked = false;
            InbreedingWeir1996Box.Checked = false;
            InbreedingHuangUnpubBox.Checked = false;
            InbreedingJackknifeBox.Checked = false;

            //Amova
            AMOVAIAMBox.Checked = true;
            AMOVASMMBox.Checked = true;
            AMOVAHomoBox.Checked = true;
            AMOVAHomoCorrBox.Checked = true;
            AMOVAAnisoBox.Checked = false;
            AMOVAGenotypeBox.Checked = false;
            AMOVAMLBox.Checked = false;
            AMOVANPermBox.Value = 999;
            AMOVAIgnoreIndBox.Checked = false;
            AMOVAOutputSSBox.Checked = false;

            //Assignment
            AssignmentPloidyBox.Checked = true;
            AssignmentErrorBox.Value = 0.01m;

            //Spatial pattern
            SpatialDistClassBox.SelectedIndex = 0;
            SpatialDistIntervalBox.Text = "100,200,400";
            SpatialHaversineBox.Checked = false;
            SpatialJackknifeBox.Checked = false;

            //Relationship
            RelationshipPopBox.Checked = true;
            RelationshipRegBox.Checked = false;
            RelationshipTotBox.Checked = false;
            RelationshipHuang2014Box.Checked = true;
            RelationshipHuang2015Box.Checked = false;
            RelationshipRitland1996mBox.Checked = true;
            RelationshipRitland1996Box.Checked = false;
            RelationshipLoiselle1995mBox.Checked = false;
            RelationshipLoiselle1995Box.Checked = false;
            RelationshipHardy1999Box.Checked = false;
            RelationshipWeir1996Box.Checked = false;
            RelationshipHuangUnpubmBox.Checked = false;
            RelationshipHuangUnpubBox.Checked = false;
            RelationshipJackknifeBox.Checked = false;

            //Heritability
            HeritabilityRitland1996Box.Checked = true;
            HeritabilityMousseau1998Box.Checked = false;
            HeritabilityThomas2000Box.Checked = false;
            HeritabilityHuangMLBox.Checked = false;
            HeritabilityHuangMOMBox.Checked = true;
            HeritabilityJackknifeBox.Checked = false;

            //Parentage
            ParentageMethodBox.SelectedIndex = 0;
            ParentageSkipSimBox.Checked = false;
            ParentagePaternityBox.Checked = true;
            ParentageParentPairBox.Checked = false;
            ParentageUnknownBox.Checked = false;
            ParentageSamplingRateBox.Value = 0.9m;
            ParentageMistypeRateBox.Value = 0.05m;

            ParentageNSimBox.Value = 10000m;
            ParentagePaternityNFatherBox.Value = 50m;
            ParentageParentPairNFatherBox.Value = 50m;
            ParentageParentPairNMotherBox.Value = 50m;
            ParentageUnknownNCandidateBox.Value = 50m;

            ParentageEstErrorBox.SelectedIndex = 0;
            ParentageErrorNSimBox.Value = 100000m;

            ParentageEstSampleBox.Checked = false;
            ParentageRedoBox.Checked = false;

            ParentageOutputBox.SelectedIndex = 1;

            //Structure
            StructureADMBox.Checked = false;
            StructureLOCPRIORIBox.Checked = false;
            StructureFmodelBox.Checked = false;
            StructureKminBox.Value = 1;
            StructureKmaxBox.Value = 5;

            StructureBurninBox.Value = 5000m;
            StructureNRepsBox.Value = 10000m;
            StructureNThinningBox.Value = 1;
            StructureNRunsBox.Value = 5;

            StructureLambdaBox.Value = 1;
            StructureStdLambdaBox.Value = 0.3m;
            StructureMaxLambdaBox.Value = 10;
            StructureADMBurninBox.Value = 500;
            StructureInferLambdaBox.Checked = false;
            StructureDiffLambdaBox.Checked = false;

            StructureAlpha0Box.Value = 1;
            StructureStdAlphaBox.Value = 0.025m;
            StructureMaxAlphaBox.Value = 10;
            StructureUpdateQBox.Value = 10;
            StructureAlphaPrioriABox.Value = 0.05m;
            StructureAlphaPrioriBBox.Value = 0.001m;
            StructureInferAlphaBox.Checked = true;
            StructureDiffAlphaBox.Checked = false;
            StructureUniformAlphaBox.Checked = true;

            StructureMaxRBox.Value = 20;
            StructureEpsRBox.Value = 0.1m;
            StructureEpsEtaBox.Value = 0.025m;
            StructureEpsGammaBox.Value = 0.025m;

            StructureFPriorMeanBox.Value = 0.01m;
            StructureFPriorStdBox.Value = 0.05m;
            StructureFStdFBox.Value = 0.05m;
            StructureFSameBox.Checked = false;

            StructureIndividualOrderBox.SelectedIndex = 0;
            StructureRearrangeColorBox.SelectedIndex = 1;

            //BayesAss
            BayesAssMethodBox.SelectedIndex = 3;
            BayesAssBurninBox.Value = 100000;
            BayesAssNRepsBox.Value = 1000000;
            BayesAssNThinningBox.Value = 100;
            BayesAssNRunsBox.Value = 10;
            BayesAssDeltaABox.Value = 0.1m;
            BayesAssDeltaFBox.Value = 0.1m;
            BayesAssDeltaMBox.Value = 0.1m;
            BayesAssPlotStyleBox.SelectedIndex = 0;
        }

        private void SaveSettings(object sender = null, EventArgs e = null)
        {
            // Save configurations into config.ini
            ApplySettings();

            if (!ISLOADING && (ARGS == null || ARGS.Length == 0))
            {
                PRESAVE = false;
                try
                {
                    StringBuilder re = new StringBuilder();
                    //Calculations
                    re.Append(CalcDistributionBox.Checked);
                    re.Append(IDENTIFIER + CalcLinkageBox.Checked);
                    re.Append(IDENTIFIER + CalcNeBox.Checked);
                    re.Append(IDENTIFIER + CalcDiffBox.Checked);
                    re.Append(IDENTIFIER + CalcDistBox.Checked);
                    re.Append(IDENTIFIER + CalcOrdinationBox.Checked);
                    re.Append(IDENTIFIER + CalcClusteringBox.Checked);
                    re.Append(IDENTIFIER + CalcInbreedingBox.Checked);
                    re.Append(IDENTIFIER + CalcHIndexBox.Checked);
                    re.Append(IDENTIFIER + CalcAssignmentBox.Checked);
                    re.Append(IDENTIFIER + CalcSpatialBox.Checked);
                    re.Append(IDENTIFIER + CalcRelationshipBox.Checked);
                    re.Append(IDENTIFIER + CalcHeritabilityBox.Checked);
                    re.Append(IDENTIFIER + CalcQstBox.Checked);
                    re.Append(IDENTIFIER + CalcParentageBox.Checked);
                    re.Append(IDENTIFIER + CalcAMOVABox.Checked);
                    re.Append(IDENTIFIER + CalcStructureBox.Checked);
                    re.Append(IDENTIFIER + CalcBayesAssBox.Checked);

                    //GLOBAL
                    re.Append(IDENTIFIER + GlobalDecimalPlaceBox.Value);
                    re.Append(IDENTIFIER + GlobalThreadBox.Value);
                    re.Append(IDENTIFIER + GlobalSeedBox.Text);
                    re.Append(IDENTIFIER + GlobalRefreshSeedBox.Checked);
                    re.Append(IDENTIFIER + GlobalWarningBox.Checked);
                    re.Append(IDENTIFIER + GlobalFoldControlBox.Checked);

                    //Simulation
                    re.Append(IDENTIFIER + SimPop_AlleleFrequencyBox.Text);
                    re.Append(IDENTIFIER + SimPop_FstTerminalBox.Text);
                    re.Append(IDENTIFIER + SimPop_DioeciousBox.Checked);
                    re.Append(IDENTIFIER + SimPop_FemaleRateBox.Value);
                    re.Append(IDENTIFIER + SimPop_SelfingRateBox.Value);
                    re.Append(IDENTIFIER + SimPop_NegPCRBox.Value);
                    re.Append(IDENTIFIER + SimPop_OutputGenotypeBox.Checked);
                    re.Append(IDENTIFIER + SimPop_SamplingRateBox.Value);
                    re.Append(IDENTIFIER + SimPop_DistBox.Text);

                    //Input
                    re.Append(IDENTIFIER + PhenotypeBox.Text);
                    re.Append(IDENTIFIER + FormatBox.SelectedIndex);

                    //Allelefrequency
                    re.Append(IDENTIFIER + FrequencyRemoveDupAlleleBox.Checked);
                    re.Append(IDENTIFIER + FrequencyNullAlleleBox.Checked);
                    re.Append(IDENTIFIER + FrequencyNegPCRBox.Checked);
                    re.Append(IDENTIFIER + FrequencySelfingBox.Checked);
                    re.Append(IDENTIFIER + FrequencySelfingRateEstimatorBox.SelectedIndex);
                    re.Append(IDENTIFIER + FrequencyInheritanceModeBox.SelectedIndex);
                    re.Append(IDENTIFIER + FrequencyNrRateBox.Value);
                    re.Append(IDENTIFIER + FrequencyResBox.Text);

                    //Diversity
                    re.Append(IDENTIFIER + DiversityResBox.Text);

                    //NE
                    re.Append(IDENTIFIER + NeNomura2008Box.Checked);
                    re.Append(IDENTIFIER + NePudovkin1996Box.Checked);
                    re.Append(IDENTIFIER + NeWaples2010Box.Checked);
                    re.Append(IDENTIFIER + NeWaplesMSBox.SelectedIndex);
                    re.Append(IDENTIFIER + NeWaplesFBox.Value);

                    //Phenotype distribution
                    re.Append(IDENTIFIER + PhenotypeTestTotBox.Checked);
                    re.Append(IDENTIFIER + PhenotypeTestRegBox.Checked);
                    re.Append(IDENTIFIER + PhenotypeTestPopBox.Checked);
                    re.Append(IDENTIFIER + DistributionResBox.Text);

                    //Linkage diseq
                    re.Append(IDENTIFIER + LinkageTestTotBox.Checked);
                    re.Append(IDENTIFIER + LinkageTestRegBox.Checked);
                    re.Append(IDENTIFIER + LinkageTestPopBox.Checked);
                    re.Append(IDENTIFIER + LinkageFisherTestBox.Checked);
                    re.Append(IDENTIFIER + LinkageBurrowsTestBox.Checked);
                    re.Append(IDENTIFIER + LinkageRaymondTestBox.Checked);
                    re.Append(IDENTIFIER + LinkageBurninBox.Value);
                    re.Append(IDENTIFIER + LinkageBatchesBox.Value);
                    re.Append(IDENTIFIER + LinkageIterationsBox.Value);
                    re.Append(IDENTIFIER + LinkageResBox.Text);

                    //Geneticdiff
                    re.Append(IDENTIFIER + DiffPopBox.Checked);
                    re.Append(IDENTIFIER + DiffRegBox.Checked);
                    re.Append(IDENTIFIER + DiffTotBox.Checked);
                    re.Append(IDENTIFIER + DiffHuang2018IAMBox.Checked);
                    re.Append(IDENTIFIER + DiffHuang2018SMMBox.Checked);
                    re.Append(IDENTIFIER + DiffSlatkin1995Box.Checked);
                    re.Append(IDENTIFIER + DiffNei1973Box.Checked);
                    re.Append(IDENTIFIER + DiffHudson1992Box.Checked);
                    re.Append(IDENTIFIER + DiffHedrick2005Box.Checked);
                    re.Append(IDENTIFIER + DiffJost2008Box.Checked);
                    re.Append(IDENTIFIER + DiffHuang2019Box.Checked);
                    re.Append(IDENTIFIER + DiffTestPhenoBox.Checked);
                    re.Append(IDENTIFIER + DiffTestAlleleBox.Checked);
                    re.Append(IDENTIFIER + DiffTestPermBox.Checked);
                    re.Append(IDENTIFIER + DiffBurninBox.Value);
                    re.Append(IDENTIFIER + DiffBatchesBox.Value);
                    re.Append(IDENTIFIER + DiffIterationsBox.Value);
                    re.Append(IDENTIFIER + DiffResBox.Text);

                    //Geneticdist
                    re.Append(IDENTIFIER + DistIndBox.Checked);
                    re.Append(IDENTIFIER + DistPopBox.Checked);
                    re.Append(IDENTIFIER + DistRegBox.Checked);
                    re.Append(IDENTIFIER + DistNei1972Box.Checked);
                    re.Append(IDENTIFIER + DistCavalli1967Box.Checked);
                    re.Append(IDENTIFIER + DistReynold1993Box.Checked);
                    re.Append(IDENTIFIER + DistNei1983Box.Checked);
                    re.Append(IDENTIFIER + DistEuclideanBox.Checked);
                    re.Append(IDENTIFIER + DistGoldstein1995Box.Checked);
                    re.Append(IDENTIFIER + DistNei1973Box.Checked);
                    re.Append(IDENTIFIER + DistRogers1973Box.Checked);
                    re.Append(IDENTIFIER + DistSokal1958Box.Checked);
                    re.Append(IDENTIFIER + DistRogers1960Box.Checked);
                    re.Append(IDENTIFIER + DistJaccard1901Box.Checked);
                    re.Append(IDENTIFIER + DistSorensen1948Box.Checked);
                    re.Append(IDENTIFIER + DistSokal1963Box.Checked);
                    re.Append(IDENTIFIER + DistRussel1940Box.Checked);
                    re.Append(IDENTIFIER + DistReynolds1983Box.Checked);
                    re.Append(IDENTIFIER + DistSlatkinBox.Checked);
                    re.Append(IDENTIFIER + DistResBox.Text);

                    //Ordination
                    re.Append(IDENTIFIER + OrdinationDimBox.Value);
                    re.Append(IDENTIFIER + OrdinationPCoABox.Checked);
                    re.Append(IDENTIFIER + OrdinationPCABox.Checked);
                    re.Append(IDENTIFIER + OrdinationFontSizeBox.Text);
                    re.Append(IDENTIFIER + OrdinationStyleBox.SelectedIndex);
                    re.Append(IDENTIFIER + OrdinationMarkerSizeBox.Text);
                    re.Append(IDENTIFIER + OrdinationMarkerBox.Text);
                    re.Append(IDENTIFIER + OrdinationAxesBox.Text);
                    re.Append(IDENTIFIER + OrdinationResBox.Text);
                    re.Append(IDENTIFIER);
                    if (OrdinationComboBox.Tag != null)
                    {
                        List<POP.ORDINATION> s = (List<POP.ORDINATION>)OrdinationComboBox.Tag;
                        foreach (POP.ORDINATION ss in s)
                        {
                            re.Append(IDENTIFIER2);
                            re.Append(ss.title);
                            re.Append(IDENTIFIER2);
                            re.Append(ss.n);
                            re.Append(IDENTIFIER2);
                            re.Append(ss.maxp);
                            for (int j = 0; j < ss.names.Length; ++j)
                            {
                                re.Append(IDENTIFIER2);
                                re.Append(ss.names[j]);
                                re.Append(IDENTIFIER2);
                                re.Append(ss.color[j]);
                            }

                            for (int i = 0; i < ss.n; ++i)
                            {
                                for (int j = 0; j < ss.maxp; ++j)
                                {
                                    re.Append(IDENTIFIER2);
                                    re.Append(ss.coordinate[i, j]);
                                }
                            }
                        }
                    }

                    //Hierarchical clustering
                    re.Append(IDENTIFIER + ClusteringNearestBox.Checked);
                    re.Append(IDENTIFIER + ClusteringFurthestBox.Checked);
                    re.Append(IDENTIFIER + ClusteringUPGMABox.Checked);
                    re.Append(IDENTIFIER + ClusteringUPGMCBox.Checked);
                    re.Append(IDENTIFIER + ClusteringWPGMABox.Checked);
                    re.Append(IDENTIFIER + ClusteringWPGMCBox.Checked);
                    re.Append(IDENTIFIER + ClusteringWARDBox.Checked);
                    re.Append(IDENTIFIER + ClusteringFontSizeBox.Text);
                    re.Append(IDENTIFIER + ClusteringLineSepBox.Text);
                    re.Append(IDENTIFIER + ClusteringResBox.Text);
                    re.Append(IDENTIFIER);
                    if (ClusteringComboBox.Tag != null)
                    {
                        List<string> s = (List<string>)ClusteringComboBox.Tag;
                        foreach (string ss in s)
                        {
                            re.Append(IDENTIFIER2);
                            re.Append(ss);
                        }
                    }

                    //Individualinbreeding
                    re.Append(IDENTIFIER + InbreedingRitland1996Box.Checked);
                    re.Append(IDENTIFIER + InbreedingLoiselle1995Box.Checked);
                    re.Append(IDENTIFIER + InbreedingWeir1996Box.Checked);
                    re.Append(IDENTIFIER + InbreedingHuangUnpubBox.Checked);
                    re.Append(IDENTIFIER + InbreedingJackknifeBox.Checked);
                    re.Append(IDENTIFIER + InbreedingResBox.Text);

                    //individual Hindex
                    re.Append(IDENTIFIER + HIndexResBox.Text);

                    //population assignment
                    re.Append(IDENTIFIER + AssignmentErrorBox.Value);
                    re.Append(IDENTIFIER + AssignmentPloidyBox.Checked);
                    re.Append(IDENTIFIER + AssignmentResBox.Text);

                    //Spatial pattern
                    re.Append(IDENTIFIER + SpatialDistClassBox.SelectedIndex);
                    re.Append(IDENTIFIER + SpatialDistIntervalBox.Text);
                    re.Append(IDENTIFIER + SpatialHaversineBox.Checked);
                    re.Append(IDENTIFIER + SpatialJackknifeBox.Checked);

                    //Relationship
                    re.Append(IDENTIFIER + RelationshipPopBox.Checked);
                    re.Append(IDENTIFIER + RelationshipRegBox.Checked);
                    re.Append(IDENTIFIER + RelationshipTotBox.Checked);
                    re.Append(IDENTIFIER + RelationshipHuang2014Box.Checked);
                    re.Append(IDENTIFIER + RelationshipHuang2015Box.Checked);
                    re.Append(IDENTIFIER + RelationshipRitland1996mBox.Checked);
                    re.Append(IDENTIFIER + RelationshipRitland1996Box.Checked);
                    re.Append(IDENTIFIER + RelationshipLoiselle1995mBox.Checked);
                    re.Append(IDENTIFIER + RelationshipLoiselle1995Box.Checked);
                    re.Append(IDENTIFIER + RelationshipHardy1999Box.Checked);
                    re.Append(IDENTIFIER + RelationshipWeir1996Box.Checked);
                    re.Append(IDENTIFIER + RelationshipHuangUnpubmBox.Checked);
                    re.Append(IDENTIFIER + RelationshipHuangUnpubBox.Checked);
                    re.Append(IDENTIFIER + RelationshipJackknifeBox.Checked);
                    re.Append(IDENTIFIER + RelationshipResBox.Text);

                    //Heritability
                    re.Append(IDENTIFIER + HeritabilityRitland1996Box.Checked);
                    re.Append(IDENTIFIER + HeritabilityMousseau1998Box.Checked);
                    re.Append(IDENTIFIER + HeritabilityThomas2000Box.Checked);
                    re.Append(IDENTIFIER + HeritabilityHuangMLBox.Checked);
                    re.Append(IDENTIFIER + HeritabilityHuangMOMBox.Checked);
                    re.Append(IDENTIFIER + HeritabilityJackknifeBox.Checked);

                    //Parentage analysis
                    re.Append(IDENTIFIER + ParentagePaternityBox.Checked);
                    re.Append(IDENTIFIER + ParentageParentPairBox.Checked);
                    re.Append(IDENTIFIER + ParentageUnknownBox.Checked);
                    re.Append(IDENTIFIER + ParentageSamplingRateBox.Value);
                    re.Append(IDENTIFIER + ParentageMistypeRateBox.Value);
                    re.Append(IDENTIFIER + ParentageNSimBox.Value);
                    re.Append(IDENTIFIER + ParentagePaternityNFatherBox.Value);
                    re.Append(IDENTIFIER + ParentageParentPairNFatherBox.Value);
                    re.Append(IDENTIFIER + ParentageParentPairNMotherBox.Value);
                    re.Append(IDENTIFIER + ParentageErrorNSimBox.Value);
                    re.Append(IDENTIFIER + ParentageUnknownNCandidateBox.Value);
                    re.Append(IDENTIFIER + ParentageOutputBox.SelectedIndex);
                    re.Append(IDENTIFIER + ParentageMethodBox.SelectedIndex);
                    re.Append(IDENTIFIER + ParentageSkipSimBox.Checked);
                    re.Append(IDENTIFIER + D2_999.Value);
                    re.Append(IDENTIFIER + D2_99.Value);
                    re.Append(IDENTIFIER + D2_95.Value);
                    re.Append(IDENTIFIER + D2_80.Value);
                    re.Append(IDENTIFIER + D1_999.Value);
                    re.Append(IDENTIFIER + D1_99.Value);
                    re.Append(IDENTIFIER + D1_95.Value);
                    re.Append(IDENTIFIER + D1_80.Value);
                    re.Append(IDENTIFIER + DPM_999.Value);
                    re.Append(IDENTIFIER + DPM_99.Value);
                    re.Append(IDENTIFIER + DPM_95.Value);
                    re.Append(IDENTIFIER + DPM_80.Value);
                    re.Append(IDENTIFIER + DPF_999.Value);
                    re.Append(IDENTIFIER + DPF_99.Value);
                    re.Append(IDENTIFIER + DPF_95.Value);
                    re.Append(IDENTIFIER + DPF_80.Value);
                    re.Append(IDENTIFIER + DP_999.Value);
                    re.Append(IDENTIFIER + DP_99.Value);
                    re.Append(IDENTIFIER + DP_95.Value);
                    re.Append(IDENTIFIER + DP_80.Value);
                    re.Append(IDENTIFIER + DPU_999.Value);
                    re.Append(IDENTIFIER + DPU_99.Value);
                    re.Append(IDENTIFIER + DPU_95.Value);
                    re.Append(IDENTIFIER + DPU_80.Value);
                    re.Append(IDENTIFIER + ParentageSimResBox.Text);
                    re.Append(IDENTIFIER + ParentagePaternityOffspringBox.Text);
                    re.Append(IDENTIFIER + ParentagePaternityResBox.Text);
                    re.Append(IDENTIFIER + ParentageParentPairOffspringBox.Text);
                    re.Append(IDENTIFIER + ParentageParentPairMotherBox.Text);
                    re.Append(IDENTIFIER + ParentageParentPairFatherBox.Text);
                    re.Append(IDENTIFIER + ParentageParentPairResBox.Text);
                    re.Append(IDENTIFIER + ParentageUnknownOffspringBox.Text);
                    re.Append(IDENTIFIER + ParentageUnknownParentBox.Text);
                    re.Append(IDENTIFIER + ParentageUnknownResBox.Text);
                    re.Append(IDENTIFIER + ParentageErrorResBox.Text);
                    re.Append(IDENTIFIER + ParentageSampleResBox.Text);
                    re.Append(IDENTIFIER + ParentageEstErrorBox.SelectedIndex);
                    re.Append(IDENTIFIER + ParentageEstSampleBox.Checked);
                    re.Append(IDENTIFIER + ParentageRedoBox.Checked);

                    //AMOVA
                    re.Append(IDENTIFIER + AMOVAIAMBox.Checked);
                    re.Append(IDENTIFIER + AMOVASMMBox.Checked);
                    re.Append(IDENTIFIER + AMOVAIgnoreIndBox.Checked);
                    re.Append(IDENTIFIER + AMOVAOutputSSBox.Checked);
                    re.Append(IDENTIFIER + AMOVANPermBox.Value);
                    re.Append(IDENTIFIER + AMOVAHomoBox.Checked);
                    re.Append(IDENTIFIER + AMOVAHomoCorrBox.Checked);
                    re.Append(IDENTIFIER + AMOVAAnisoBox.Checked);
                    re.Append(IDENTIFIER + AMOVAGenotypeBox.Checked);
                    re.Append(IDENTIFIER + AMOVAMLBox.Checked);
                    re.Append(IDENTIFIER + GlobalRegionBox.Text);
                    re.Append(IDENTIFIER + AMOVAResBox.Text);

                    //Structure
                    re.Append(IDENTIFIER + StructureADMBox.Checked);
                    re.Append(IDENTIFIER + StructureLOCPRIORIBox.Checked);
                    re.Append(IDENTIFIER + StructureFmodelBox.Checked);
                    re.Append(IDENTIFIER + StructureKminBox.Value);
                    re.Append(IDENTIFIER + StructureKmaxBox.Value);

                    re.Append(IDENTIFIER + StructureBurninBox.Value);
                    re.Append(IDENTIFIER + StructureNRepsBox.Value);
                    re.Append(IDENTIFIER + StructureNThinningBox.Value);
                    re.Append(IDENTIFIER + StructureNRunsBox.Value);

                    re.Append(IDENTIFIER + StructureLambdaBox.Value);
                    re.Append(IDENTIFIER + StructureStdLambdaBox.Value);
                    re.Append(IDENTIFIER + StructureMaxLambdaBox.Value);
                    re.Append(IDENTIFIER + StructureADMBurninBox.Value);
                    re.Append(IDENTIFIER + StructureInferLambdaBox.Checked);
                    re.Append(IDENTIFIER + StructureDiffLambdaBox.Checked);

                    re.Append(IDENTIFIER + StructureAlpha0Box.Value);
                    re.Append(IDENTIFIER + StructureStdAlphaBox.Value);
                    re.Append(IDENTIFIER + StructureMaxAlphaBox.Value);
                    re.Append(IDENTIFIER + StructureUpdateQBox.Value);
                    re.Append(IDENTIFIER + StructureInferAlphaBox.Checked);
                    re.Append(IDENTIFIER + StructureDiffAlphaBox.Checked);
                    re.Append(IDENTIFIER + StructureUniformAlphaBox.Checked);
                    re.Append(IDENTIFIER + StructureAlphaPrioriABox.Value);
                    re.Append(IDENTIFIER + StructureAlphaPrioriBBox.Value);

                    re.Append(IDENTIFIER + StructureMaxRBox.Value);
                    re.Append(IDENTIFIER + StructureEpsRBox.Value);
                    re.Append(IDENTIFIER + StructureEpsEtaBox.Value);
                    re.Append(IDENTIFIER + StructureEpsGammaBox.Value);

                    re.Append(IDENTIFIER + StructureFPriorMeanBox.Value);
                    re.Append(IDENTIFIER + StructureFPriorStdBox.Value);
                    re.Append(IDENTIFIER + StructureFStdFBox.Value);
                    re.Append(IDENTIFIER + StructureFSameBox.Checked);

                    re.Append(IDENTIFIER + StructureIndividualOrderBox.SelectedIndex);
                    re.Append(IDENTIFIER + StructureRearrangeColorBox.SelectedIndex);
                    re.Append(IDENTIFIER + StructureRunDetailBox.Text);

                    //BayesAss
                    re.Append(IDENTIFIER + BayesAssMethodBox.SelectedIndex);
                    re.Append(IDENTIFIER + BayesAssBurninBox.Value);
                    re.Append(IDENTIFIER + BayesAssNRepsBox.Value);
                    re.Append(IDENTIFIER + BayesAssNThinningBox.Value);
                    re.Append(IDENTIFIER + BayesAssNRunsBox.Value);
                    re.Append(IDENTIFIER + BayesAssDeltaABox.Value);
                    re.Append(IDENTIFIER + BayesAssDeltaFBox.Value);
                    re.Append(IDENTIFIER + BayesAssDeltaMBox.Value);
                    re.Append(IDENTIFIER + BayesAssPlotStyleBox.SelectedIndex);

                    //Mantel
                    re.Append(IDENTIFIER + MantelNPermBox.Value);
                    re.Append(IDENTIFIER + MantelResBox.Text);
                    re.Append(IDENTIFIER + MantelMatBox.Text);

                    //Form1
                    re.Append(IDENTIFIER + ImportFileDialog.FileName);
                    re.Append(IDENTIFIER + SavePicDialog.FileName);
                    re.Append(IDENTIFIER + SaveDataDialog.FileName);

                    //Form3
                    re.Append(IDENTIFIER + f3.PloidyBox.Value);
                    re.Append(IDENTIFIER + f3.MissingBox.Value);
                    re.Append(IDENTIFIER + f3.FirstRowBox.Checked);
                    re.Append(IDENTIFIER + f3.SecondColumnBox.Checked);
                    re.Append(IDENTIFIER + f3.PhaseBox.Checked);
                    re.Append(IDENTIFIER + f3.SingleRowBox.Checked);
                    re.Append(IDENTIFIER + f3.FileBox.Text);
                    re.Append(IDENTIFIER + f3.ImportFileDialog.FileName);

                    //Form4
                    re.Append(IDENTIFIER + f4.dr0.Checked);
                    re.Append(IDENTIFIER + f4.dr1.Checked);
                    re.Append(IDENTIFIER + f4.dr2.Checked);
                    re.Append(IDENTIFIER + f4.dr3.Checked);
                    re.Append(IDENTIFIER + f4.dr4.Checked);
                    re.Append(IDENTIFIER + f4.dr5.Checked);
                    re.Append(IDENTIFIER + f4.self0.Checked);
                    re.Append(IDENTIFIER + f4.self1.Checked);
                    re.Append(IDENTIFIER + f4.self2.Checked);
                    re.Append(IDENTIFIER + f4.self3.Checked);
                    re.Append(IDENTIFIER + f4.py0.Checked);
                    re.Append(IDENTIFIER + f4.py1.Checked);
                    re.Append(IDENTIFIER + f4.beta0.Checked);
                    re.Append(IDENTIFIER + f4.beta1.Checked);

                    //Form5
                    re.Append(IDENTIFIER + f5.MethodBox.SelectedIndex);
                    re.Append(IDENTIFIER + f5.FormatBox.SelectedIndex);
                    re.Append(IDENTIFIER + f5.FillMissingBox.SelectedIndex);
                    re.Append(IDENTIFIER + f5.RepeatBox.Value);
                    re.Append(IDENTIFIER + f5.NFileBox.Value);
                    re.Append(IDENTIFIER + f5.NullBox.Value);
                    re.Append(IDENTIFIER + f5.MaxNBox.Value);
                    re.Append(IDENTIFIER + f5.DirBox.Text);
                    re.Append(IDENTIFIER + f5.ExportFolderDialog.SelectedPath);

                    //Form6
                    re.Append(IDENTIFIER + f6.OutputStyleBox.SelectedIndex);
                    re.Append(IDENTIFIER + f6.NAlleleBox1.Value);
                    re.Append(IDENTIFIER + f6.NAlleleBox2.Value);
                    re.Append(IDENTIFIER + f6.FilterBox.Text);
                    re.Append(IDENTIFIER + f6.QualBox.Value);
                    re.Append(IDENTIFIER + f6.HeBox.Value);
                    re.Append(IDENTIFIER + f6.GenotypeRateBox.Value);
                    re.Append(IDENTIFIER + f6.MAFBox.Value);
                    re.Append(IDENTIFIER + f6.WindowSizeBox.Value);
                    re.Append(IDENTIFIER + f6.GQBox.Value);
                    re.Append(IDENTIFIER + f6.DPBox.Value);
                    re.Append(IDENTIFIER + f6.FileBox.Text);
                    re.Append(IDENTIFIER + f6.ImportFileDialog.FileName);

                    File.WriteAllText(cdir + "config.ini", re.ToString(), Encoding.UTF8);
                }
                catch { }
            }
        }

        public void PreSaveSettings(object sender = null, EventArgs e = null)
        {
            // Delay save configuration to reduce disk IO

            ShowControls();
            ApplySettings();
            PRESAVE = true;
        }
        #endregion

        #region SIMULATION

        private void GenerageFounderPopulation(object sender, EventArgs e)
        {
            // Generate the genotypes for founders

            runstate = GlobalRunState.notstart;
            if (THREAD != null && THREAD.ThreadState == System.Threading.ThreadState.Running)
                THREAD.Abort();
            ApplySettings();

            string[] s = SimPop_AlleleFrequencyBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (s.Length < 2)
            {
                ShowErrorMessage("Allele frequency configuration is empty.", "Error", 0);
                return;
            }

            POP tpop = null;
            if (SEED_REFRESH)
            {
                GlobalSeedBox.Value = GLOBAL_RND.Next((int)(GlobalSeedBox.Maximum + 1)) % (int)(GlobalSeedBox.Maximum + 1);
                SEED = (int)GlobalSeedBox.Value;
            }

            simpops = new List<POP>();
            try
            {
                for (int i = 0; i <= s.Length; ++i)
                {
                    if (i == s.Length)
                    {
                        simpops.Add(tpop);
                        break;
                    }
                    s[i] = s[i].TrimEnd(new char[] { ' ', '\t' });
                    if (s[i].Length >= 6 && s[i].Substring(0, 6).ToLower() == "ploidy")
                    {
                        if (tpop != null)
                            simpops.Add(tpop);
                        string[] sl = s[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        tpop = new POP();
                        tpop.name = "pop" + (simpops.Count + 1).ToString();
                        tpop.rnd_sim = new Random(SEED ^ (i + 0x20024));
                        tpop.ploidy_sim = int.Parse(sl[1]);
                        tpop.n = int.Parse(sl[3]);
                        if (tpop.n <= 1 || tpop.n > MAX_INDS)
                        {
                            ShowErrorMessage("Number of individuals out of range [2," + MAX_INDS + "].", "Error", 0);
                            simpops = null;
                            return;
                        }

                        s[i + 2] = s[i + 2].TrimEnd(new char[] { ' ', '\t' });

                        sl = s[i + 1].Split(new char[] { '\t' }, StringSplitOptions.None);
                        int L = s[i + 1].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        tpop.loc_sim = new LOC[L];
                        for (int l = 0; l < L; ++l)
                        {
                            if (sl[l * 2] != "")
                            {
                                tpop.loc_sim[l] = new LOC();
                                tpop.loc_sim[l].name = sl[l * 2];
                                tpop.loc_sim[l].s = SIMPOP_SELFING_RATIO;
                                tpop.loc_sim[l].beta = SIMPOP_BETA_RATIO;
                            }
                        }
                        i++;
                    }
                    else
                    {
                        string[] sl = s[i].Split(new char[] { '\t' }, StringSplitOptions.None);
                        for (int l = 0; l < tpop.loc_sim.Length; l++)
                            if (sl[l * 2].ToLower() == "null")
                                tpop.loc_sim[l].freq.Add(NULL_ALLELE, double.Parse(sl[l * 2 + 1]));
                            else
                                tpop.loc_sim[l].freq.Add(int.Parse(sl[l * 2]), double.Parse(sl[l * 2 + 1]));

                    }
                }
            }
            catch
            {
                ShowErrorMessage("Wrong allele frequency configuration format.", "Error", 0);
                simpops = null;
                return;
            }

            foreach (LOC l in tpop.loc_sim)
            {
                if (l.freq.Count > MAX_ALLELES)
                {
                    ShowErrorMessage("Number of alleles exceed " + MAX_ALLELES + ". At " + l.name + ".", "Error", 0);
                    simpops = null;
                    return;
                }
            }

            if (!simpops[0].GetAlphaSim(simpops[0].loc_sim.Length))
            {
                simpops = null;
                return;
            }

            StringBuilder w = new StringBuilder();
            simpops[0].WriteHeader(w);
            int cindcount = 0;

            foreach (POP pp in simpops)
            {
                pp.ALPHA = simpops[0].ALPHA;
                pp.UnifyPop(pp.loc_sim);
                //foreach (LOC l in pp.loc_sim)
                Parallel.ForEach(pp.loc_sim, new ParallelOptions { MaxDegreeOfParallelism = N_THREAD }, l =>
                {
                    l.Generator(pp.ploidy_sim, pp.ALPHA[l.id, pp.ploidy_sim]);
                });
                pp.AddInds();
                pp.WriteGenotype(w, ref cindcount);
            }

            PhenotypeBox.Text = w.ToString();
            FormatBox.SelectedIndex = SIMPOP_OUTPUT_GENOTYPE ? 1 : 0;

            fst = POP.GetFst(simpops.Select(p => p.GetSubPopSim()).ToArray(), FstEstimator.SimNei1973);
            GenLabel.Text = "Generation: " + simpops[0].generation_sim;
            FstLabel.Text = "Fst: " + fst.ToString(DECIMAL);
            ApplySettings();
            return;
        }

        public static int nsim = 0;
        public static int nsimstart = 0;
        public static double fst = 0;
        public static List<POP> simpops = new List<POP>();

        private void Reproduce(object sender, EventArgs e)
        {
            // Generate offspring using current generation as parents

            if (runstate == GlobalRunState.simulating)
                return;

            if (THREAD != null && THREAD.ThreadState == System.Threading.ThreadState.Running)
                THREAD.Abort();

            ToolStripButton t = (ToolStripButton)sender;
            if (simpops == null || simpops.Count == 0)
                GenerageFounderPopulation(null, null);

            if (simpops == null) return;
            foreach (POP p in simpops)
                if (p.ploidy_sim % 2 == 1)
                {
                    ShowErrorMessage("Can not simulate odd ploidy.", "Error", 0);
                    runstate = GlobalRunState.notstart;
                    return;
                }

            nsim = int.Parse(t.Text);
            nsimstart = simpops[0].generation_sim;
            if (THREAD != null) THREAD.Abort();
            toolStripProgressBar1.Maximum = nsim;
            toolStripProgressBar1.Value = 0;
            THREAD = new Thread(new ThreadStart(POP.ReproduceThread));
            THREAD.Start();
        }

        private void ReproduceUntilFst(object sender, EventArgs e)
        {
            // Keep reproduce offspring generation-by-generation
            // until Fst reach some predefined value

            if (runstate == GlobalRunState.simulating)
                return;

            if (THREAD != null && THREAD.ThreadState == System.Threading.ThreadState.Running)
                THREAD.Abort();

            if (simpops == null || simpops.Count == 0)
                GenerageFounderPopulation(null, null);

            foreach (POP p in simpops)
                if (p.ploidy_sim % 2 == 1)
                {
                    ShowErrorMessage("Can not simulate odd ploidy.", "Error", 0);
                    runstate = GlobalRunState.notstart;
                    return;
                }

            nsim = 1000000;
            nsimstart = simpops[0].generation_sim;
            if (THREAD != null) THREAD.Abort();
            THREAD = new Thread(new ThreadStart(ReproduceFst));
            toolStripProgressBar1.Maximum = nsim;
            toolStripProgressBar1.Value = 0;
            THREAD.Start();
        }

        public void ReproduceFst()
        {
            // Keep reproduce offspring generation-by-generation
            // until Fst reach some predefined value

            runstate = GlobalRunState.simulating;
            while (true)
            {
                foreach (POP p in simpops)
                    p.Reproduce();
                for (int i = 0; i < simpops.Count; ++i)
                    simpops[i].UpdateAlleleFreqSim();
                fst = POP.GetFst(simpops.Select(p => p.GetSubPopSim()).ToArray(), FstEstimator.SimNei1973);
                if (fst >= SIMPOP_FST_TERMINAL)
                    break;
            }
            runstate = GlobalRunState.simulated;
        }
        #endregion

        #region FOLD_CONTROL
        public TabPage[] TABPAGES = null;
        public GroupBox[] GROUPBOXES = null;
        public Point[] PREVIOUSPOS = null;
        public bool SIZE_CHANGED = false;
        public bool PLOT_BAYESASS = false;
        public bool PLOT_STRUCTURE = false;

        public void Form1_SizeChanged(object sender, EventArgs e)
        {
            SIZE_CHANGED = true;
        }

        public void ShowPanel(object sender = null, EventArgs e = null)
        {
            if (ISLOADING) return;
            SIZE_CHANGED = false;
            PreSaveSettings();

            //Linkage
            {
                Control[] ctrl = new Control[] { label85, label86, label84, LinkageBurninBox, LinkageBatchesBox, LinkageIterationsBox };
                Array.ForEach(ctrl, c => { c.Enabled = LINKAGE_RAYMOND; c.Visible = LINKAGE_RAYMOND || !FOLD_CONTROL; });
                GroupBoxLinkage.Height = (int)((LINKAGE_RAYMOND || !FOLD_CONTROL ? 144 : 100) * DPI_SCALE + 0.4999);
            }

            //Genetic diff
            {
                Control[] ctrl = new Control[] { label68, label67, label83, DiffBurninBox, DiffBatchesBox, DiffIterationsBox };
                Array.ForEach(ctrl, c => { c.Enabled = DIFF_TESTPERM; c.Visible = DIFF_TESTPERM || !FOLD_CONTROL; });
                GroupBoxDiff.Height = (int)((DIFF_TESTPERM || !FOLD_CONTROL ? 272 : 224) * DPI_SCALE + 0.4999);
            }

            //Ne
            {
                Control[] ctrl = new Control[] { Label109, label111, NeWaplesMSBox, NeWaplesFBox };
                Array.ForEach(ctrl, c => { c.Enabled = NE_WAPLES2010; c.Visible = NE_WAPLES2010 || !FOLD_CONTROL; });
                GroupBoxNe.Height = (int)((NE_WAPLES2010 || !FOLD_CONTROL ? 129 : 83) * DPI_SCALE + 0.4999);
            }

            //Structure
            {
                int cy = (int)(284 * DPI_SCALE + 0.4999), ysep = (int)(8 * DPI_SCALE + 0.4999);
                Control[][] ctrl = new Control[][]{
                    new Control[] { label30, label21, label22, label48, label49, label99, label100, StructureAlpha0Box, StructureStdAlphaBox, StructureMaxAlphaBox, StructureUpdateQBox, StructureAlphaPrioriABox, StructureAlphaPrioriBBox, StructureInferAlphaBox, StructureDiffAlphaBox, StructureUniformAlphaBox },
                    new Control[] { label31, label23, label24, label25, label26, StructureMaxRBox, StructureEpsRBox, StructureEpsEtaBox, StructureEpsGammaBox },
                    new Control[] { label32, label33, label34, label41, StructureFPriorMeanBox, StructureFPriorStdBox, StructureFStdFBox, StructureFSameBox } };
                bool[] bin = new bool[] { STRUCTURE_ADMIXTURE, STRUCTURE_LOCPRIORI, STRUCTURE_FMODEL };

                for (int i = 0; i < 3; ++i)
                {
                    Array.ForEach(ctrl[i], c => { c.Enabled = bin[i]; c.Visible = bin[i] || !FOLD_CONTROL; });
                    if (bin[i] || !FOLD_CONTROL)
                    {
                        int ymin = ctrl[i].Min(c => c.Location.Y), ymax = ctrl[i].Max(c => c.Location.Y + c.Height);
                        Array.ForEach(ctrl[i], c => c.Location = new Point(c.Location.X, c.Location.Y + cy - ymin));
                        cy += ymax - ymin + ysep;
                    }
                }

                GroupBoxStructure.Height = cy;
            }

            //Parentage
            {
                int cy = (int)(149 * DPI_SCALE + 0.4999), ysep = (int)(0 * DPI_SCALE + 0.4999);
                Control[][] ctrl = new Control[][]{
                    new Control[] { label80, ParentagePaternityNFatherBox },
                    new Control[] { label79, label78, ParentageParentPairNFatherBox, ParentageParentPairNMotherBox },
                    new Control[] { label77, label18, ParentageUnknownNCandidateBox },
                    new Control[] {label81, label103, label51, ParentageEstErrorBox, ParentageErrorNSimBox, ParentageEstSampleBox, ParentageRedoBox, ParentageOutputBox } };
                bool[] bin = new bool[] { PARENTAGE_PATERNITY, PARENTAGE_PARENTPAIR, PARENTAGE_UNKNOWN, true };

                for (int i = 0; i < bin.Length; ++i)
                {
                    Array.ForEach(ctrl[i], c => { c.Enabled = bin[i]; c.Visible = bin[i] || !FOLD_CONTROL; });
                    if (bin[i] || !FOLD_CONTROL)
                    {
                        int ymin = ctrl[i].Min(c => c.Location.Y), ymax = ctrl[i].Max(c => c.Location.Y + c.Height);
                        Array.ForEach(ctrl[i], c => c.Location = new Point(c.Location.X, c.Location.Y + cy - ymin));
                        cy += ymax - ymin + ysep;
                    }
                }
                GroupBoxParentage.Height = cy + (int)(8 * DPI_SCALE + 0.4999);
            }

            //Groupboxes
            {
                int scrolldistance = ParametersPanel.VerticalScroll.Value;

                if (GROUPBOXES == null)
                {
                    GROUPBOXES = new GroupBox[]
                      { GroupBoxDistribution, GroupBoxLinkage, GroupBoxNe,
                        GroupBoxDiff, GroupBoxDist, GroupBoxOrdination, GroupBoxClustering, GroupBoxInbreeding, null, GroupBoxAssignment, GroupBoxSpatial,
                        GroupBoxRelationship, GroupBoxHeritability, null, GroupBoxAMOVA, GroupBoxParentage, GroupBoxStructure, GroupBoxBayesAss };
                    TABPAGES = new TabPage[]
                          { DistributionPage, LinkagePage, NePage, DiffPage, DistPage, OrdinationPage,
                          ClusteringPage, InbreedingPage, HIndexPage, AssignmentPage, SpatialPage, RelationshipPage, HeritabilityPage, QstPage, AMOVAPage,
                          ParentagePage, StructurePage, BayesAssPage };
                    PREVIOUSPOS = new Point[GROUPBOXES.Length];
                }

                bool[] bin = new bool[]
                        { CALC_DISTRIBUTION, CALC_LINKAGE, CALC_NE, CALC_DIFF, CALC_DIST, CALC_ORDINATION, CALC_CLUSTERING,
                        CALC_INBREEDING, CALC_HINDEX, CALC_ASSIGNMENT, CALC_SPATIAL, CALC_RELATIONSHIP, CALC_HERITABILITY, CALC_QST, CALC_AMOVA,
                        CALC_PARENTAGE, CALC_STRUCTURE, CALC_BAYESASS };

                int cwidth = GroupBoxMethods.Width;
                int x0 = (int)(3 * DPI_SCALE + 0.4999), y0 = (int)(1 * DPI_SCALE + 0.4999);
                int ysep = (int)(6 * DPI_SCALE + 0.4999), xsep = (int)(6 * DPI_SCALE + 0.4999);
                int ncol = Math.Max(1, (int)((splitContainer20.Panel2.Width - xsep * DPI_SCALE) / (cwidth + xsep * DPI_SCALE)));

                Point[] cp = new Point[ncol];
                for (int i = 0; i < ncol; ++i)
                    cp[i] = new Point(x0 + (cwidth + xsep) * i, y0);

                Point[] pts = GROUPBOXES.Select(o => o == null ? new Point() : o.Location).ToArray();
                ParametersPanel.VerticalScroll.Value = 0;
                ParametersPanel.HorizontalScroll.Value = 0;
                for (int i = 0, p = 4; i < GROUPBOXES.Length; ++i)
                {
                    if (FOLD_CONTROL)
                    {
                        if (bin[i] && !tabControl1.TabPages.Contains(TABPAGES[i]))
                            tabControl1.TabPages.Insert(p, TABPAGES[i]);
                        else if (!bin[i]) tabControl1.TabPages.Remove(TABPAGES[i]);
                        if (bin[i]) p++;
                    }
                    else if (!tabControl1.TabPages.Contains(TABPAGES[i]))
                        tabControl1.TabPages.Insert(i + 4, TABPAGES[i]);

                    GroupBox b = GROUPBOXES[i];
                    if (b == null) continue;

                    b.Enabled = bin[i];
                    b.Visible = !FOLD_CONTROL || bin[i];
                    if (!FOLD_CONTROL || bin[i])
                    {
                        int miny = cp.Min(pt => pt.Y);
                        int cpid = Array.FindIndex(cp, pt => pt.Y == miny);
                        pts[i] = cp[cpid];
                        cp[cpid].Y += b.Height + ysep;
                    }
                }

                bool update = false;
                for (int i = 0; i < GROUPBOXES.Length; ++i)
                    if (PREVIOUSPOS[i] != pts[i])
                    {
                        update = true;
                        break;
                    }

                for (int i = 0; update && i < GROUPBOXES.Length; ++i)
                    if (GROUPBOXES[i] != null)
                        GROUPBOXES[i].Location = PREVIOUSPOS[i] = pts[i];

                ParametersPanel.VerticalScroll.Value = scrolldistance;
            }

            ShowControls();
        }

        public void ShowControls()
        {
            SimPop_FemaleRateBox.Enabled = SimPop_DioeciousBox.Checked;
            SimPop_SelfingRateBox.Enabled = !SimPop_DioeciousBox.Checked;

            //Frequency
            FrequencySelfingBox.Enabled = FrequencyInheritanceModeBox.SelectedIndex != 5;
            FrequencySelfingRateEstimatorBox.Enabled = FrequencySelfingBox.Enabled && FrequencySelfingBox.Checked;

            //Linkage
            LinkageBurninBox.Enabled = LinkageRaymondTestBox.Checked;
            LinkageBatchesBox.Enabled = LinkageRaymondTestBox.Checked;
            LinkageIterationsBox.Enabled = LinkageRaymondTestBox.Checked;

            //Differentiation
            DiffBurninBox.Enabled = DiffTestPermBox.Checked;
            DiffBatchesBox.Enabled = DiffTestPermBox.Checked;
            DiffIterationsBox.Enabled = DiffTestPermBox.Checked;

            //Ne
            NeWaplesMSBox.Enabled = NeWaples2010Box.Checked;
            NeWaplesFBox.Enabled = NeWaples2010Box.Checked && NeWaplesMSBox.SelectedIndex == 4;

            //Spatial
            SpatialDistIntervalBox.Enabled = SpatialDistClassBox.SelectedIndex == 0;

            //AMOVA
            AMOVAHomoCorrBox.Enabled = AMOVAHomoBox.Checked;

            //Parentage
            ParentagePaternityNFatherBox.Enabled = ParentagePaternityBox.Checked;
            ParentageParentPairNFatherBox.Enabled = ParentageParentPairBox.Checked;
            ParentageParentPairNMotherBox.Enabled = ParentageParentPairBox.Checked;
            ParentageUnknownNCandidateBox.Enabled = ParentageUnknownBox.Checked;
            ParentageRedoBox.Enabled = ParentageEstSampleBox.Checked;

            //Structure
            StructureAlpha0Box.Enabled = StructureADMBox.Checked;
            StructureStdAlphaBox.Enabled = StructureADMBox.Checked;
            StructureMaxAlphaBox.Enabled = StructureADMBox.Checked;
            StructureUpdateQBox.Enabled = StructureADMBox.Checked;
            StructureInferAlphaBox.Enabled = StructureADMBox.Checked;
            StructureDiffAlphaBox.Enabled = StructureADMBox.Checked;
            StructureUniformAlphaBox.Enabled = StructureADMBox.Checked;

            StructureAlphaPrioriABox.Enabled = StructureADMBox.Checked && !StructureUniformAlphaBox.Checked;
            StructureAlphaPrioriBBox.Enabled = StructureADMBox.Checked && !StructureUniformAlphaBox.Checked;

            StructureMaxRBox.Enabled = StructureLOCPRIORIBox.Checked;
            StructureEpsRBox.Enabled = StructureLOCPRIORIBox.Checked;
            StructureEpsEtaBox.Enabled = StructureLOCPRIORIBox.Checked;
            StructureEpsGammaBox.Enabled = StructureLOCPRIORIBox.Checked;

            StructureFPriorMeanBox.Enabled = StructureFmodelBox.Checked;
            StructureFPriorStdBox.Enabled = StructureFmodelBox.Checked;
            StructureFStdFBox.Enabled = StructureFmodelBox.Checked;
            StructureFSameBox.Enabled = StructureFmodelBox.Checked;
        }
        #endregion

        #region MAINTOOL & PARAMETER_PAGE
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == ParametersPage)
                ShowPanel();
            PreSaveSettings();
        }

        public void Pause(object sender, EventArgs e)
        {
            if (runstate != GlobalRunState.running &&
                runstate != GlobalRunState.simulating &&
                runstate != GlobalRunState.mantelrunning)
                return;

            ToolStripButton tb = (ToolStripButton)sender;
            if (tb.Text == "&Pause")
            {
                if (THREAD != null && THREAD.IsAlive)
                    THREAD.Suspend();

                if (THREAD_Ex != null && THREAD_Ex.IsAlive)
                    THREAD_Ex.Suspend();

                foreach (Thread th in THREAD_LIST)
                    if (th != null && th.IsAlive)
                        th.Suspend();

                tb.Text = "&Resume";
            }
            else
            {
                if (THREAD != null && THREAD.IsAlive)
                    THREAD.Resume();

                if (THREAD_Ex != null && THREAD.IsAlive)
                    THREAD_Ex.Resume();

                foreach (Thread th in THREAD_LIST)
                    if (th != null && th.IsAlive)
                        th.Resume();

                tb.Text = "&Pause";
            }
        }

        public void Abort(object sender, EventArgs e)
        {
            if (runstate == GlobalRunState.notstart) return;
            runstate = GlobalRunState.end;
            MODEL_TEST = false;

            if (all != null)
                all.ProgressValue = all.ProgressMax;

            while (THREAD != null && THREAD.IsAlive)
            {
                try { THREAD.Resume(); }
                catch { }
                THREAD.Abort();
            }

            while (THREAD_Ex != null && THREAD_Ex.IsAlive)
            {
                try { THREAD_Ex.Resume(); }
                catch { }
                THREAD_Ex.Abort();
            }

            if (THREAD_LIST != null) foreach (Thread th in THREAD_LIST.ToArray())
                {
                    while (th != null && th.IsAlive)
                    {
                        try { th.Resume(); }
                        catch { }
                        th.Abort();
                    }
                    THREAD_LIST.Remove(th);
                }

            if (OUTPUT_FREQUENCY != null && OUTPUT_FREQUENCY.BaseStream != null) OUTPUT_FREQUENCY.Close();
            if (OUTPUT_DIVERSITY != null && OUTPUT_DIVERSITY.BaseStream != null) OUTPUT_DIVERSITY.Close();
            if (OUTPUT_DISTRIBUTION != null && OUTPUT_DISTRIBUTION.BaseStream != null) OUTPUT_DISTRIBUTION.Close();
            if (OUTPUT_LINKAGE != null && OUTPUT_LINKAGE.BaseStream != null) OUTPUT_LINKAGE.Close();
            if (OUTPUT_NE != null && OUTPUT_NE.BaseStream != null) OUTPUT_NE.Close();
            if (OUTPUT_DIFFERENTIATION != null && OUTPUT_DIFFERENTIATION.BaseStream != null) OUTPUT_DIFFERENTIATION.Close();
            if (OUTPUT_DISTANCE != null && OUTPUT_DISTANCE.BaseStream != null) OUTPUT_DISTANCE.Close();
            if (OUTPUT_PCOA != null && OUTPUT_PCOA.BaseStream != null) OUTPUT_PCOA.Close();
            if (OUTPUT_CLUSTERING != null && OUTPUT_CLUSTERING.BaseStream != null) OUTPUT_CLUSTERING.Close();
            if (OUTPUT_INBREEDING != null && OUTPUT_INBREEDING.BaseStream != null) OUTPUT_INBREEDING.Close();
            if (OUTPUT_HINDEX != null && OUTPUT_HINDEX.BaseStream != null) OUTPUT_HINDEX.Close();
            if (OUTPUT_ASSIGNMENT != null && OUTPUT_ASSIGNMENT.BaseStream != null) OUTPUT_ASSIGNMENT.Close();
            if (OUTPUT_HERITABILITY != null && OUTPUT_HERITABILITY.BaseStream != null) OUTPUT_HERITABILITY.Close();
            if (OUTPUT_RELATIONSHIP != null && OUTPUT_RELATIONSHIP.BaseStream != null) OUTPUT_RELATIONSHIP.Close();
            if (OUTPUT_QST != null && OUTPUT_QST.BaseStream != null) OUTPUT_QST.Close();
            if (OUTPUT_PARENTAGE_SIMULATION != null && OUTPUT_PARENTAGE_SIMULATION.BaseStream != null) OUTPUT_PARENTAGE_SIMULATION.Close();
            if (OUTPUT_PARENTAGE_PATERNITY != null && OUTPUT_PARENTAGE_PATERNITY.BaseStream != null) OUTPUT_PARENTAGE_PATERNITY.Close();
            if (OUTPUT_PARENTAGE_PARENTPAIR != null && OUTPUT_PARENTAGE_PARENTPAIR.BaseStream != null) OUTPUT_PARENTAGE_PARENTPAIR.Close();
            if (OUTPUT_PARENTAGE_UNKNOWN != null && OUTPUT_PARENTAGE_UNKNOWN.BaseStream != null) OUTPUT_PARENTAGE_UNKNOWN.Close();
            if (OUTPUT_PARENTAGE_ERROR != null && OUTPUT_PARENTAGE_ERROR.BaseStream != null) OUTPUT_PARENTAGE_ERROR.Close();
            if (OUTPUT_PARENTAGE_SAMPLERATE != null && OUTPUT_PARENTAGE_SAMPLERATE.BaseStream != null) OUTPUT_PARENTAGE_SAMPLERATE.Close();
            if (OUTPUT_AMOVA != null && OUTPUT_AMOVA.BaseStream != null) OUTPUT_AMOVA.Close();
            if (OUTPUT_MANTEL != null && OUTPUT_MANTEL.BaseStream != null) OUTPUT_MANTEL.Close();

            PauseButton.Text = "&Pause";
        }

        private void ShowManual(object sender, EventArgs e)
        {
            if (File.Exists(cdir + "Manual.pdf"))
            {
                System.Diagnostics.Process pexec = new System.Diagnostics.Process();
                pexec.StartInfo.FileName = cdir + "Manual.pdf";
                pexec.StartInfo.Arguments = "start";
                pexec.Start();
                pexec.WaitForExit();
            }
        }

        private void ShowAbout(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void ProgressTimerTick(object sender, EventArgs e)
        {
            try
            {
                switch (runstate)
                {
                    default:
                    case GlobalRunState.notstart:
                        if (!InputPage.Enabled) InputPage.Enabled = true;
                        if (!ParametersPage.Enabled) ParametersPage.Enabled = true;
                        break;

                    case GlobalRunState.running:
                        if (InputPage.Enabled) InputPage.Enabled = false;
                        if (ParametersPage.Enabled) ParametersPage.Enabled = false;
                        if (TaskLabel.Text != all.Progress) TaskLabel.Text = all.Progress;
                        toolStripProgressBar1.Maximum = all.ProgressMax;
                        toolStripProgressBar1.Value = all.ProgressValue > toolStripProgressBar1.Maximum ? toolStripProgressBar1.Maximum : all.ProgressValue;
                        break;

                    case GlobalRunState.end:
                        runstate = GlobalRunState.notstart;
                        if (!InputPage.Enabled) InputPage.Enabled = true;
                        if (!ParametersPage.Enabled) ParametersPage.Enabled = true;

                        if (CALC_CLUSTERING)
                        {
                            ClusteringComboBox.Items.Clear();
                            ClusteringComboBox.Tag = all.clustering_out;
                            ClusteringComboBox.Items.AddRange(all.clustering_out.Select(s => s.Substring(0, s.IndexOf(':'))).ToArray());
                        }

                        if (CALC_ORDINATION)
                        {
                            OrdinationComboBox.Items.Clear();
                            OrdinationComboBox.Tag = all.ordination_results;
                            OrdinationComboBox.Items.AddRange(all.ordination_results.Select(o => o.title).ToArray());
                        }

                        if (CALC_STRUCTURE)
                            LoadStructureResultFiles();

                        if (CALC_BAYESASS)
                            LoadBayesAssResultFiles();

                        TaskLabel.Text = "";
                        toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
                        SaveSettings();
                        ShowControls();
                        break;

                    case GlobalRunState.simulating:
                        if (InputPage.Enabled) InputPage.Enabled = false;
                        if (ParametersPage.Enabled) ParametersPage.Enabled = false;
                        toolStripProgressBar1.Value = simpops[0].generation_sim - nsimstart;
                        TaskLabel.Text = "Simulating";
                        GenLabel.Text = "Generation: " + simpops[0].generation_sim;
                        FstLabel.Text = "Fst: " + fst.ToString(DECIMAL);
                        break;

                    case GlobalRunState.simulated:
                        if (!InputPage.Enabled) InputPage.Enabled = true;
                        if (!ParametersPage.Enabled) ParametersPage.Enabled = true;
                        TaskLabel.Text = "";
                        toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
                        runstate = GlobalRunState.simulatedend;

                        StringBuilder w = new StringBuilder();
                        simpops[0].WriteHeader(w);
                        int cindcount = 0;
                        foreach (POP pp in simpops)
                            pp.WriteGenotype(w, ref cindcount);
                        PhenotypeBox.Text = w.ToString();
                        FormatBox.SelectedIndex = SIMPOP_OUTPUT_GENOTYPE ? 1 : 0;
                        fst = POP.GetFst(simpops.Select(p => p.GetSubPopSim()).ToArray(), FstEstimator.SimNei1973);
                        GenLabel.Text = "Generation: " + simpops[0].generation_sim;
                        FstLabel.Text = "Fst: " + fst.ToString(DECIMAL);

                        ApplySettings();
                        ShowControls();
                        break;

                    case GlobalRunState.mantelrunning:
                        if (InputPage.Enabled) InputPage.Enabled = false;
                        if (ParametersPage.Enabled) ParametersPage.Enabled = false;
                        toolStripProgressBar1.Maximum = MANTEL_NPERM;
                        toolStripProgressBar1.Value = MANTEL_CPERM;
                        TaskLabel.Text = "Mantel testing";
                        break;

                    case GlobalRunState.mantelend:
                        if (!InputPage.Enabled) InputPage.Enabled = true;
                        if (!ParametersPage.Enabled) ParametersPage.Enabled = true;
                        toolStripProgressBar1.Maximum = MANTEL_NPERM;
                        toolStripProgressBar1.Value = MANTEL_NPERM;
                        TaskLabel.Text = "";
                        SetText(f1.MantelResBox, GetFileSize("o_mantel.txt") < MAX_OUTPUT ? File.ReadAllText("o_mantel.txt") : "Can not display Mantel test results for output size > 10Mb, Mantel test output is saved in file 'o_mantel.txt'.");
                        runstate = GlobalRunState.notstart;
                        SaveSettings();
                        ShowControls();
                        break;

                    case GlobalRunState.mantelbreak:
                        if (!InputPage.Enabled) InputPage.Enabled = true;
                        if (!ParametersPage.Enabled) ParametersPage.Enabled = true;
                        toolStripProgressBar1.Maximum = MANTEL_NPERM;
                        toolStripProgressBar1.Value = 0;
                        TaskLabel.Text = "";
                        MantelResBox.Text = "Error";
                        runstate = GlobalRunState.notstart;
                        ApplySettings();
                        ShowControls();
                        break;
                }
            }
            catch
            {

            }
        }

        private void BeginCalculation(object sender, EventArgs e)
        {
            if (runstate == GlobalRunState.running || runstate == GlobalRunState.mantelrunning || runstate == GlobalRunState.simulating || runstate == GlobalRunState.end) return;

            SaveSettings();

            //reset results
            DiversityResBox.Text = FrequencyResBox.Text = DiffResBox.Text = DistributionResBox.Text = InbreedingResBox.Text = AMOVAResBox.Text = HIndexResBox.Text = AssignmentResBox.Text = RelationshipResBox.Text = LinkageResBox.Text = DistResBox.Text = "";
            ParentagePaternityResBox.Text = ParentageParentPairResBox.Text = ParentageUnknownResBox.Text = ParentageErrorResBox.Text = ParentageSampleResBox.Text = ParentageSimResBox.Text = OrdinationResBox.Text = ClusteringResBox.Text = "";
            ClusteringComboBox.Tag = null;
            OrdinationComboBox.Tag = null;
            ClusteringPicBox.Image = null;
            OrdinationPicBox.Image = null;

            //update seed
            if (SEED_REFRESH)
            {
                GlobalSeedBox.Value = GLOBAL_RND.Next((int)(GlobalSeedBox.Maximum + 1)) % (int)(GlobalSeedBox.Maximum + 1);
                SEED = (int)GlobalSeedBox.Value;
            }

            SaveSettings();

            runstate = GlobalRunState.running;

            if (CALC_PARENTAGE)
            {
                PATERNITY_OFFSPRING = ParentagePaternityOffspringBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                PARENTPAIR_OFFSPRING = ParentageParentPairOffspringBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                PARENTPAIR_FATHER = ParentageParentPairFatherBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                PARENTPAIR_MOTHER = ParentageParentPairMotherBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                UNKNOWN_OFFSPRING = ParentageUnknownOffspringBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                UNKNOWN_PARENT = ParentageUnknownParentBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (THREAD != null) THREAD.Abort();
            THREAD = new Thread(new ThreadStart(UICalcThread));
            THREAD.Start();
        }

        private void RandomizeGlobalSeed(object sender, EventArgs e)
        {
            GlobalSeedBox.Value = GLOBAL_RND.Next((int)(GlobalSeedBox.Maximum + 1));
            SEED = (int)GlobalSeedBox.Value;
        }

        private void UICalcThread()
        {
            //input data are ready
            if (runstate != GlobalRunState.running) return;

            all = new POP();
            all.form1 = this;
            all.Calc();
            runstate = GlobalRunState.end;
        }

        private void RandomizeLocusDistance(object sender, EventArgs e)
        {
            string[] t1 = SimPop_AlleleFrequencyBox.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (t1.Length == 0) return;
            int nloc = t1[1].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            string output = "";
            for (int i = 0; i < nloc; ++i)
                output += GLOBAL_RND.Next(100) + "\r\n";
            SimPop_DistBox.Text = output;
        }

        private void ImportPolyRelatedness(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
            {
                string[] data = File.ReadAllLines(ImportFileDialog.FileName);
                StreamWriter wt = new StreamWriter(new MemoryStream());
                wt.Write("ID\tPop\tPloidy");

                int cp = 0;
                while (cp < data.Length && data[cp].Length >= 15 && data[cp].Substring(0, 15) != "//#alleledigits") cp++;
                if (cp == data.Length)
                {
                    ShowErrorMessage("Cannot find file header of polyrelatedness format.", "Error", 0);
                    return;
                }
                int ndigit = 0, missing = 0, amb = 0;
                string[] pars = data[++cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ndigit = int.Parse(pars[0]);
                missing = int.Parse(pars[2]);
                amb = int.Parse(pars[3]);

                while (cp < data.Length && data[cp].Length >= 10 && data[cp].Substring(0, 10) != "//genotype") cp++;
                if (cp == data.Length)
                {
                    ShowErrorMessage("Cannot find genotype table header of polyrelatedness format.", "Error", 0);
                    return;
                }

                cp += 2;
                pars = data[cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 2; i < pars.Length; ++i)
                {
                    wt.Write("\t");
                    wt.Write(pars[i]);
                }

                bool isgenotype = true;
                for (int i = ++cp; i < data.Length; ++i)
                {
                    if (data[i].Length >= 13 && data[i].Substring(0, 13) == "//end of file") break;
                    pars = data[i].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    wt.Write("\r\n");
                    wt.Write(pars[0]);
                    wt.Write("\t");
                    wt.Write(pars[1]);
                    int ploidy = pars[2].Length / ndigit;
                    wt.Write("\t");
                    wt.Write(ploidy);

                    for (int j = 2; j < pars.Length; ++j)
                    {
                        int ploidy2 = pars[j].Length / ndigit;
                        if (ploidy != ploidy2)
                        {
                            ShowErrorMessage("Do not support anisoploid.", "Error", 0);
                            return;
                        }

                        wt.Write("\t");
                        List<int> alleles = new List<int>();
                        bool ismissing = false;
                        for (int k = 0; k < ploidy; ++k)
                        {
                            int tal = int.Parse(pars[j].Substring(k * ndigit, ndigit));
                            if (tal == missing) ismissing = true;
                            else if (tal != amb) alleles.Add(tal);
                        }

                        if (alleles.Count < ploidy) isgenotype = false;
                        if (ismissing || alleles.Count == 0) continue;

                        wt.Write(alleles[0]);
                        for (int k = 1; k < alleles.Count; ++k)
                        {
                            wt.Write(",");
                            wt.Write(alleles[k]);
                        }
                    }
                }
                wt.Flush();
                StreamReader rt = new StreamReader(wt.BaseStream);
                rt.BaseStream.Position = 0;
                File.WriteAllText("input.txt", rt.ReadToEnd());

                rt.BaseStream.Position = 0;
                PhenotypeBox.Text = rt.BaseStream.Length < 1024 * 1024 ? rt.ReadToEnd() : "input.txt";
                FormatBox.SelectedIndex = isgenotype ? 1 : 0;
                wt.Close();
            }
        }

        private void ImportSpagedi(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
            {
                string[] data = File.ReadAllLines(ImportFileDialog.FileName);
                StreamWriter wt = new StreamWriter(new MemoryStream());
                wt.Write("ID\tPop\tPloidy");

                int cp = 0;
                while (cp < data.Length && data[cp].Length >= 2 && data[cp].Substring(0, 2) == "//") cp++;
                int ndigit = 0, missing = 0, ncoor = 0;
                string[] pars = data[cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ndigit = int.Parse(pars[4]);
                missing = 0;
                ncoor = int.Parse(pars[2]);

                pars = data[++cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder re = new StringBuilder();
                for (int i = 0; i < int.Parse(pars[0]); ++i)
                    re.Append(i == 0 ? pars[1 + i] : "," + pars[1 + i]);
                SpatialDistClassBox.SelectedIndex = 0;
                SpatialDistIntervalBox.Text = re.ToString();
                pars = data[++cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 2; i < pars.Length; ++i)
                {
                    wt.Write("\t");
                    wt.Write(i - 2 < ncoor ? "[C]" + pars[i] : pars[i]);
                }

                bool isgenotype = true;
                Dictionary<string, int> popv = new Dictionary<string, int>();

                for (int i = ++cp; i < data.Length; ++i)
                {
                    if (data[i].Length >= 3 && data[i].Substring(0, 3) == "END") break;
                    pars = data[i].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int ploidy = 1;
                    for (int j = 2 + ncoor; j < pars.Length; ++j)
                        ploidy = (int)Math.Max(ploidy, (int)Math.Ceiling((double)pars[j].Length / ndigit));
                    if (!popv.ContainsKey(pars[1]))
                        popv[pars[1]] = ploidy;
                    else
                        popv[pars[1]] = Math.Max(popv[pars[1]], ploidy);
                }

                for (int i = ++cp; i < data.Length; ++i)
                {
                    if (data[i].Length >= 3 && data[i].Substring(0, 3) == "END") break;
                    pars = data[i].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    wt.Write("\r\n");
                    wt.Write(pars[0]);
                    wt.Write("\t");
                    wt.Write(pars[1]);
                    wt.Write("\t");
                    int ploidy = popv[pars[1]];
                    wt.Write(ploidy);

                    for (int j = 2; j < 2 + ncoor; ++j)
                    {
                        wt.Write("\t");
                        wt.Write(pars[j]);
                    }

                    for (int j = 2 + ncoor; j < pars.Length; ++j)
                    {
                        pars[j] = pars[j].PadLeft(ploidy * ndigit, '0');
                        wt.Write("\t");
                        List<int> alleles = new List<int>();
                        bool ismissing = false;
                        for (int k = 0; k < ploidy; ++k)
                        {
                            int tal = int.Parse(pars[j].Substring(k * ndigit, ndigit));
                            if (tal == missing) ismissing = true;
                            else alleles.Add(tal);
                        }

                        if (alleles.Count < ploidy) isgenotype = false;
                        if (ismissing || alleles.Count == 0) continue;

                        wt.Write(alleles[0]);
                        for (int k = 1; k < alleles.Count; ++k)
                        {
                            wt.Write(",");
                            wt.Write(alleles[k]);
                        }
                    }
                }
                wt.Flush();
                StreamReader rt = new StreamReader(wt.BaseStream);
                rt.BaseStream.Position = 0;
                File.WriteAllText("input.txt", rt.ReadToEnd());

                rt.BaseStream.Position = 0;
                PhenotypeBox.Text = rt.BaseStream.Length < 1024 * 1024 ? rt.ReadToEnd() : "input.txt";
                FormatBox.SelectedIndex = isgenotype ? 1 : 0;
                wt.Close();
            }
        }

        private void ImportGenodive(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
            {
                string[] data = File.ReadAllLines(ImportFileDialog.FileName);
                StreamWriter wt = new StreamWriter(new MemoryStream());
                wt.Write("ID\tPop\tPloidy");

                int cp = 1;
                string[] pars = data[cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int ndigit = int.Parse(pars[4]);
                int npop = int.Parse(pars[1]);
                string[] subpopnames = new string[npop];
                int missing = 0;

                for (int s = 0; s < npop; ++s)
                    subpopnames[s] = data[++cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];

                pars = data[++cp].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 2; i < pars.Length; ++i)
                {
                    wt.Write("\t");
                    wt.Write(pars[i]);
                }

                bool isgenotype = true;
                for (int i = ++cp; i < data.Length; ++i)
                {
                    if (data[i].Length <= 5) break;
                    pars = data[i].Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int ploidy = pars[2].Length / ndigit;

                    wt.Write("\r\n");
                    wt.Write(pars[1]);
                    wt.Write("\t");
                    wt.Write(subpopnames[int.Parse(pars[0]) - 1]);
                    wt.Write("\t");
                    wt.Write(ploidy);

                    for (int j = 2; j < pars.Length; ++j)
                    {
                        int ploidy2 = pars[j].Length / ndigit;
                        if (ploidy != ploidy2)
                        {
                            ShowErrorMessage("Do not support anisoploid.", "Error", 0);
                            return;
                        }

                        wt.Write("\t");
                        List<int> alleles = new List<int>();
                        bool ismissing = false;
                        for (int k = 0; k < ploidy; ++k)
                        {
                            int tal = int.Parse(pars[j].Substring(k * ndigit, ndigit));
                            if (tal == missing) ismissing = true;
                            else alleles.Add(tal);
                        }

                        if (alleles.Count < ploidy) isgenotype = false;
                        if (ismissing || alleles.Count == 0) continue;

                        wt.Write(alleles[0]);
                        for (int k = 1; k < alleles.Count; ++k)
                        {
                            wt.Write(",");
                            wt.Write(alleles[k]);
                        }
                    }
                }
                wt.Flush();
                StreamReader rt = new StreamReader(wt.BaseStream);
                rt.BaseStream.Position = 0;
                File.WriteAllText("input.txt", rt.ReadToEnd());

                rt.BaseStream.Position = 0;
                PhenotypeBox.Text = rt.BaseStream.Length < 1024 * 1024 ? rt.ReadToEnd() : "input.txt";
                FormatBox.SelectedIndex = isgenotype ? 1 : 0;
                wt.Close();
            }
        }

        private void ImportGenepop(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
            {
                string[] genepop = File.ReadAllLines(ImportFileDialog.FileName);
                StreamWriter wt = new StreamWriter(new MemoryStream());
                wt.Write("ID\tPop\tPloidy");
                int cpop = 0;
                for (int i = 1; i < genepop.Length; ++i)
                {
                    while (genepop[i][0] == ' ')
                        genepop[i] = genepop[i].Substring(1);
                    if (genepop[i].Substring(0, 3).ToLower() == "pop" && (genepop[i].Length == 3 || genepop[i][4] == ' '))
                        cpop++;
                    else if (cpop == 0)
                        wt.Write("\t" + genepop[i]);
                    else
                    {
                        string[] t = genepop[i].Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.None);
                        wt.Write("\r\n" + t[0] + "\tpop" + cpop + "\t2");
                        for (int j = 1; j < t.Length; ++j)
                        {
                            if (t[j].Length == 0) continue;
                            if (int.Parse(t[j].Substring(0, t[j].Length / 2)) != 0)
                                wt.Write("\t" + t[j].Substring(0, t[j].Length / 2) + "," + t[j].Substring(t[j].Length / 2));
                            else
                                wt.Write("\t");
                        }
                    }
                }
                wt.Flush();
                StreamReader rt = new StreamReader(wt.BaseStream);
                rt.BaseStream.Position = 0;
                File.WriteAllText("input.txt", rt.ReadToEnd());

                rt.BaseStream.Position = 0;
                PhenotypeBox.Text = rt.BaseStream.Length < 1024 * 1024 ? rt.ReadToEnd() : "input.txt";
                FormatBox.SelectedIndex = 1;
                wt.Close();
            }
        }

        private void ImportStructure(object sender, EventArgs e)
        {
            Form3.result = "";
            f3.ShowDialog();
            if (Form3.result.Length > 0)
            {
                File.WriteAllText("input.txt", Form3.result);
                PhenotypeBox.Text = Form3.result.Length < 1024 * 1024 ? Form3.result : "input.txt";
                FormatBox.SelectedIndex = 1;
                Form3.result = "";
            }
        }

        private void ImportVCF(object sender, EventArgs e)
        {
            Form6.result = "";
            f6.ShowDialog();
            if (Form6.result.Length > 0)
            {
                File.WriteAllText("input.txt", Form6.result);
                PhenotypeBox.Text = Form6.result.Length < 1024 * 1024 ? Form6.result : "input.txt";
                FormatBox.SelectedIndex = Form6.outputstyle;
                Form6.result = "";
            }
        }

        #endregion

        #region CONTROL
        private void ToolStripKeyDown(object sender, KeyEventArgs e)
        {
            ToolStripTextBox tb = (ToolStripTextBox)sender;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    tb.Text = (int.Parse(tb.Text) + 1).ToString();
                    break;
                case Keys.PageUp:
                    tb.Text = (int.Parse(tb.Text) + 10).ToString();
                    break;
                case Keys.Down:
                    tb.Text = (int.Parse(tb.Text) - 1).ToString();
                    break;
                case Keys.PageDown:
                    tb.Text = (int.Parse(tb.Text) - 10).ToString();
                    break;
                case Keys.Enter:
                    tb.Text = tb.Text;
                    break;
            }
        }

        private void ToolStripBoxChanged(ToolStripTextBox tb, ref int val, int min, int max, System.Action action)
        {
            int.TryParse(ToIntegerString(tb.Text), out val);
            val = val < min ? min : val;
            val = val > max ? max : val;

            if (val.ToString() != tb.Text)
                tb.Text = val.ToString();
            else
            {
                PRESAVE = true;
                action.Invoke();
            }
        }

        private void SavePic(object sender, EventArgs e)
        {
            PictureBox picbox = (PictureBox)(((ToolStripButton)sender).Tag);
            if (picbox.Image != null)
            {
                SavePicDialog.FileName = SavePicDialog.FileName == "" ? resdir + "output.png" : SavePicDialog.FileName;
                if (DialogResult.OK == SavePicDialog.ShowDialog())
                {
                    switch (SavePicDialog.FileName.Substring(SavePicDialog.FileName.Length - 3).ToLower())
                    {
                        case "bmp": picbox.Image.Save(SavePicDialog.FileName, ImageFormat.Bmp); break;
                        case "gif": picbox.Image.Save(SavePicDialog.FileName, ImageFormat.Gif); break;
                        case "jpg": picbox.Image.Save(SavePicDialog.FileName, ImageFormat.Jpeg); break;
                        case "png": picbox.Image.Save(SavePicDialog.FileName, ImageFormat.Png); break;
                        case "tif": picbox.Image.Save(SavePicDialog.FileName, ImageFormat.Tiff); break;
                        case "emf": File.WriteAllBytes(SavePicDialog.FileName, (byte[])picbox.Tag); break;
                        case "wmf": File.WriteAllBytes(SavePicDialog.FileName, (byte[])picbox.Tag); break;
                    }
                }
            }
        }

        private void ScrollPic(object sender, EventArgs e)
        {
            ToolStripButton bu = (ToolStripButton)sender;
            ToolStripComboBox cb = (ToolStripComboBox)bu.Tag;
            if (bu.Text.Contains("Next"))
            {
                if (cb.Items.Count > 0 && cb.SelectedIndex < cb.Items.Count - 1)
                    cb.SelectedIndex++;
            }
            else
            {
                if (cb.Items.Count > 0 && cb.SelectedIndex > 0)
                    cb.SelectedIndex--;
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == OrdinationPage && f1.RectangleToClient(OrdinationToolStrip.RectangleToScreen(OrdinationFontSizeBox.Bounds)).Contains(e.Location))
            {
                ORDINATION_FONT_SIZE += e.Delta > 0 ? 1 : -1;
                if (ORDINATION_FONT_SIZE <= 0)
                    ORDINATION_FONT_SIZE = 1;
                OrdinationFontSizeBox.Text = ORDINATION_FONT_SIZE.ToString();
            }

            if (tabControl1.SelectedTab == OrdinationPage && f1.RectangleToClient(OrdinationToolStrip.RectangleToScreen(OrdinationMarkerSizeBox.Bounds)).Contains(e.Location))
            {
                ORDINATION_MARKER_SIZE += e.Delta > 0 ? 1 : -1;
                if (ORDINATION_MARKER_SIZE <= 0)
                    ORDINATION_MARKER_SIZE = 1;
                OrdinationMarkerSizeBox.Text = ORDINATION_MARKER_SIZE.ToString();
            }

            if (tabControl1.SelectedTab == ClusteringPage && f1.RectangleToClient(ClusteringToolStrip.RectangleToScreen(ClusteringFontSizeBox.Bounds)).Contains(e.Location))
            {
                CLUSTERING_FONT_SIZE += e.Delta > 0 ? 1 : -1;
                if (CLUSTERING_FONT_SIZE < 0)
                    CLUSTERING_FONT_SIZE = 0;
                ClusteringFontSizeBox.Text = CLUSTERING_FONT_SIZE.ToString();
            }

            if (tabControl1.SelectedTab == ClusteringPage && f1.RectangleToClient(ClusteringToolStrip.RectangleToScreen(ClusteringLineSepBox.Bounds)).Contains(e.Location))
            {
                CLUSTERING_LINE_SEP += e.Delta > 0 ? 1 : -1;
                if (CLUSTERING_LINE_SEP < 0)
                    CLUSTERING_LINE_SEP = 0;
                ClusteringLineSepBox.Text = CLUSTERING_LINE_SEP.ToString();
            }
        }
        #endregion

        #region STRUCTURE

        public class StructureResultItem
        {
            public string file;
            public string str;
            public ListViewItem[] items;

            public StructureResultItem(string _file)
            {
                file = _file;
            }
        }

        private void LoadStructureResultFiles()
        {
            StructureRunListBox.Items.Clear();
            StructureResultFileBox.Items.Clear();
            int[] fids = new DirectoryInfo(resdir).GetFiles("Structure_*.dat").Select(f => int.Parse(f.Name.Substring(10, f.Name.Length - 14))).ToArray();
            Array.Sort(fids);
            StructureResultFileBox.Items.AddRange(fids.Select(f => POP.STRUCTURE.ReadResultFile(resdir + "Structure_" + f + ".dat")).ToArray());
        }

        private void StructureResultFileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StructurePicBox.Image = null;
            StructureRunDetailBox.Text = "";
            StructureRunListBox.Items.Clear();

            if (StructureResultFileBox.SelectedItems.Count == 1)
            {
                StructureResultItem res = (StructureResultItem)StructureResultFileBox.SelectedItems[0].Tag;

                if (!File.Exists(res.file))
                {
                    StructureResultFileBox.SelectedItems[0].Remove();
                    return;
                }
                if (res.items == null) POP.STRUCTURE.ReadRuns(res);

                StructureRunListBox.Items.AddRange(res.items);
                StructureRunDetailBox.Text = res.str;
            }
        }

        private void PlotStructure()
        {
            PLOT_STRUCTURE = false;
            if (StructureRunListBox.SelectedItems.Count > 1)
            {
                StructureResultItem res = (StructureResultItem)StructureResultFileBox.SelectedItems[0].Tag;
                POP.STRUCTURE par = new POP.STRUCTURE(res.file);
                POP.STRUCTURE[] pars = new POP.STRUCTURE[StructureRunListBox.SelectedItems.Count];
                for (int i = 0; i < pars.Length; ++i)
                    pars[i] = (POP.STRUCTURE)StructureRunListBox.SelectedItems[i].Tag;
                if (pars.Length == 0) return;

                par.Summary(pars);
                StructureRunDetailBox.Text = par.GetRunString(pars);
                byte[] VecFile = null;
                StructurePicBox.Image = par.DrawBarplot(ref VecFile, pars);
                StructurePicBox.Tag = VecFile;
            }
        }

        private void StructureRunListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clusteringfile
            StructurePicBox.Image = null;
            StructureRunDetailBox.Text = "";
            ApplySettings();

            if (StructureResultFileBox.SelectedItems.Count != 1)
                return;

            try
            {
                if (StructureRunListBox.SelectedItems.Count == 0)
                    StructureRunDetailBox.Text = ((StructureResultItem)StructureResultFileBox.SelectedItems[0].Tag).str;
                else if (StructureRunListBox.SelectedItems.Count == 1)
                {
                    POP.STRUCTURE p = (POP.STRUCTURE)StructureRunListBox.SelectedItems[0].Tag;
                    StructureRunDetailBox.Text = p.GetRunString(null);
                    byte[] VecFile = null;
                    StructurePicBox.Image = p.DrawBarplot(ref VecFile, null);
                    StructurePicBox.Tag = VecFile;
                }
                else if (StructureRunListBox.SelectedItems.Count > 1)
                    PLOT_STRUCTURE = true;
            }
            catch
            { }
        }

        private void StructureIndividualOrderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PRESAVE = true;
            STRUCTURE_STYLE = (StructurePlotType)StructureIndividualOrderBox.SelectedIndex;
            StructureRunListBox_SelectedIndexChanged(sender, e);
        }

        private void StructureRearrangeColorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PRESAVE = true;
            STRUCTURE_REARRANGE = OrdinationStyleBox.SelectedIndex == 0;
            StructureRunListBox_SelectedIndexChanged(sender, e);
        }

        private void ShowStructureResultMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                contextMenuStrip2.Show(Form1.MousePosition);
        }

        private void DeleteAllResult(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == StructurePage)
            {
                foreach (FileInfo f in new DirectoryInfo(resdir).GetFiles("Structure_*.dat"))
                {
                    try
                    {
                        File.Delete(f.FullName);
                    }
                    catch
                    {

                    }
                }
                LoadStructureResultFiles();
            }

            if (tabControl1.SelectedTab == BayesAssPage)
            {
                foreach (FileInfo f in new DirectoryInfo(resdir).GetFiles("BayesAss_*.dat"))
                {
                    try
                    {
                        File.Delete(f.FullName);
                    }
                    catch
                    {

                    }
                }
                LoadBayesAssResultFiles();
            }

        }

        private void DeleteResult(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == StructurePage)
            {
                for (int i = 0; i < StructureResultFileBox.SelectedItems.Count; ++i)
                {
                    try { File.Delete(((StructureResultItem)StructureResultFileBox.SelectedItems[i].Tag).file); }
                    catch { }
                }
                LoadStructureResultFiles();
            }

            if (tabControl1.SelectedTab == BayesAssPage)
            {
                for (int i = 0; i < BayesAssResultFileBox.SelectedItems.Count; ++i)
                {
                    try { File.Delete(((BayesAssResultItem)BayesAssResultFileBox.SelectedItems[i].Tag).file); }
                    catch { }
                }
                LoadBayesAssResultFiles();
            }

        }
        #endregion

        #region BAYESASS

        public class BayesAssResultItem
        {
            public string file;
            public DateTime time;
            public ListViewItem item;
            public ListViewItem[] items;
            public string str;

            public BayesAssResultItem(string _file, ListViewItem _item)
            {
                file = _file;
                item = _item;
                time = new FileInfo(file).CreationTime;
            }
        }

        private void ExportlnL(object sender, EventArgs e)
        {
            ToolStripButton tb = (ToolStripButton)sender;

            if (tb == ExportStructureButton && StructureRunListBox.Items.Count > 0 &&
                DialogResult.OK == SaveDataDialog.ShowDialog())
            {
                POP.STRUCTURE[] pars = null;
                if (StructureRunListBox.SelectedItems.Count == 0)
                {
                    pars = new POP.STRUCTURE[StructureRunListBox.Items.Count];
                    for (int i = 0; i < pars.Length; ++i)
                        pars[i] = (POP.STRUCTURE)StructureRunListBox.Items[i].Tag;
                }
                else
                {
                    pars = new POP.STRUCTURE[StructureRunListBox.SelectedItems.Count];
                    for (int i = 0; i < pars.Length; ++i)
                        pars[i] = (POP.STRUCTURE)StructureRunListBox.SelectedItems[i].Tag;
                }
                POP.STRUCTURE.WritelnL(pars, SaveDataDialog.FileName);
            }

            if (tb == ExportBayesAssButton && BayesAssRunListBox.Items.Count > 0 &&
                DialogResult.OK == SaveDataDialog.ShowDialog())
            {
                POP.BAYESASS[] pars = null;
                if (BayesAssRunListBox.SelectedItems.Count == 0)
                {
                    pars = new POP.BAYESASS[BayesAssRunListBox.Items.Count];
                    for (int i = 0; i < pars.Length; ++i)
                        pars[i] = (POP.BAYESASS)BayesAssRunListBox.Items[i].Tag;
                }
                else
                {
                    pars = new POP.BAYESASS[BayesAssRunListBox.SelectedItems.Count];
                    for (int i = 0; i < pars.Length; ++i)
                        pars[i] = (POP.BAYESASS)BayesAssRunListBox.SelectedItems[i].Tag;
                }
                POP.BAYESASS.WritelnL(pars, SaveDataDialog.FileName);
            }
        }

        private void ExportBayesAssDetails(object sender, EventArgs e)
        {
            if (BayesAssRunListBox.SelectedItems.Count > 0 && DialogResult.OK == SaveDataDialog.ShowDialog())
            {
                if (BayesAssRunListBox.SelectedItems.Count > 1)
                {
                    BayesAssResultItem res = (BayesAssResultItem)BayesAssResultFileBox.SelectedItems[0].Tag;
                    POP.BAYESASS par = new POP.BAYESASS(res.file);
                    POP.BAYESASS[] pars = new POP.BAYESASS[BayesAssRunListBox.SelectedItems.Count];
                    for (int i = 0; i < pars.Length; ++i)
                        pars[i] = (POP.BAYESASS)BayesAssRunListBox.SelectedItems[i].Tag;
                    if (pars.Length == 0) return;

                    par.Summary(pars);
                    par.GetRunString(pars);
                    File.WriteAllText(SaveDataDialog.FileName, par.res_detail);
                }
                else
                {
                    POP.BAYESASS p = (POP.BAYESASS)BayesAssRunListBox.SelectedItems[0].Tag;
                    File.WriteAllText(SaveDataDialog.FileName, p.res_detail);
                }
            }
        }

        private void PlotBayesAss()
        {
            PLOT_BAYESASS = false;
            if (BayesAssRunListBox.SelectedItems.Count > 1)
            {
                BayesAssResultItem res = (BayesAssResultItem)BayesAssResultFileBox.SelectedItems[0].Tag;
                POP.BAYESASS par = new POP.BAYESASS(res.file);
                POP.BAYESASS[] pars = new POP.BAYESASS[BayesAssRunListBox.SelectedItems.Count];
                for (int i = 0; i < pars.Length; ++i)
                    pars[i] = (POP.BAYESASS)BayesAssRunListBox.SelectedItems[i].Tag;
                if (pars.Length == 0) return;

                par.Summary(pars);
                BayesAssRunDetailBox.Text = par.GetRunString(pars);
                byte[] VecFile = null;
                BayesAssPicBox.Image = par.DrawBarplot(ref VecFile, pars);
                BayesAssPicBox.Tag = VecFile;
            }
        }

        private void BayesAssRunListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BayesAssPicBox.Image = null;
            BayesAssRunDetailBox.Text = "";
            ApplySettings();

            if (BayesAssResultFileBox.SelectedItems.Count != 1)
                return;

            try
            {
                if (BayesAssRunListBox.SelectedItems.Count == 0)
                {
                    BayesAssResultItem res = (BayesAssResultItem)BayesAssResultFileBox.SelectedItems[0].Tag;
                    BayesAssRunDetailBox.Text = res.str;
                }
                else if (BayesAssRunListBox.SelectedItems.Count == 1)
                {
                    POP.BAYESASS p = (POP.BAYESASS)BayesAssRunListBox.SelectedItems[0].Tag;
                    BayesAssRunDetailBox.Text = p.GetRunString(null);
                    byte[] VecFile = null;
                    BayesAssPicBox.Image = p.DrawBarplot(ref VecFile, null);
                    BayesAssPicBox.Tag = VecFile;
                }
                else if (BayesAssRunListBox.SelectedItems.Count > 1)
                    PLOT_BAYESASS = true;
            }
            catch
            { }
        }

        private void BayesAssPlotStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PRESAVE = true;
            BAYESASS_PLOTSTYLE = (BayesAssPlotType)BayesAssPlotStyleBox.SelectedIndex;
            BayesAssRunListBox_SelectedIndexChanged(sender, e);
        }

        private void ShowBayesAssResultMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                contextMenuStrip2.Show(Form1.MousePosition);
        }

        private void LoadBayesAssResultFiles()
        {
            BayesAssRunListBox.Items.Clear();
            BayesAssResultFileBox.Items.Clear();
            int[] fids = new DirectoryInfo(resdir).GetFiles("BayesAss_*.dat").Select(f => int.Parse(f.Name.Substring(9, f.Name.Length - 13))).ToArray();
            Array.Sort(fids);
            BayesAssResultFileBox.Items.AddRange(fids.Select(f => POP.BAYESASS.ReadResultFile(resdir + "BayesAss_" + f + ".dat")).ToArray());
        }

        private void BayesAssResultFileBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BayesAssPicBox.Image = null;
            BayesAssRunDetailBox.Text = "";
            BayesAssRunListBox.Items.Clear();

            if (BayesAssResultFileBox.SelectedItems.Count == 1)
            {
                BayesAssResultItem res = (BayesAssResultItem)BayesAssResultFileBox.SelectedItems[0].Tag;

                if (!File.Exists(res.file))
                {
                    BayesAssResultFileBox.SelectedItems[0].Remove();
                    return;
                }

                if (res.items == null)
                    POP.BAYESASS.ReadRuns(res);

                BayesAssRunListBox.Items.AddRange(res.items);
                BayesAssRunDetailBox.Text = res.str;
            }
        }
        #endregion

        #region ORDINATION & CLUSTERING

        private void OrdinationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrdinationComboBox.Items.Count > 0 && OrdinationComboBox.SelectedIndex >= 0)
            {
                if (PRESAVE) ApplySettings();
                List<POP.ORDINATION> ordination_results = (List<POP.ORDINATION>)OrdinationComboBox.Tag;
                if (ordination_results != null)
                {
                    byte[] VecFile = null;
                    OrdinationPicBox.Image = ordination_results[OrdinationComboBox.SelectedIndex].DrawOrdination(ref VecFile, OrdinationPicBox.Width, OrdinationPicBox.Height);
                    OrdinationPicBox.Tag = VecFile;
                }
                else
                    OrdinationPicBox.Image = null;
                if (OrdinationPicBox.Image != null)
                    OrdinationPicBox.Height = OrdinationPicBox.Image != null ? OrdinationPicBox.Image.Height : 50;
            }
        }

        private void OrdinationStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PRESAVE = true;
            ORDINATION_STYLE = OrdinationStyleBox.SelectedIndex;
            OrdinationComboBox_SelectedIndexChanged(sender, e);
        }

        private void OrdinationMarkerBox_TextChanged(object sender, EventArgs e)
        {
            if (OrdinationMarkerBox.Text == "")
                OrdinationMarkerBox.Text = " ";
            else
            {
                PRESAVE = true;
                ORDINATION_MARKER = OrdinationMarkerBox.Text;
                OrdinationComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void OrdinationAxesBox_TextChanged(object sender, EventArgs e)
        {
            PRESAVE = true;
            ORDINATION_AXES = OrdinationAxesBox.Text;
            OrdinationComboBox_SelectedIndexChanged(sender, e);
        }

        private void OrdinationFontSizeBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripBoxChanged((ToolStripTextBox)sender, ref ORDINATION_FONT_SIZE, 1, 100,
                delegate () { OrdinationComboBox_SelectedIndexChanged(sender, e); });
        }

        private void OrdinationMarkerSizeBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripBoxChanged((ToolStripTextBox)sender, ref ORDINATION_MARKER_SIZE, 1, 100,
                delegate () { OrdinationComboBox_SelectedIndexChanged(sender, e); });
        }

        private void ClusteringFontSizeBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripBoxChanged((ToolStripTextBox)sender, ref CLUSTERING_FONT_SIZE, 1, 100,
                delegate () { ClusteringComboBox_SelectedIndexChanged(sender, e); });
        }

        private void ClusteringLineSepBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripBoxChanged((ToolStripTextBox)sender, ref CLUSTERING_LINE_SEP, 1, 100,
                delegate () { ClusteringComboBox_SelectedIndexChanged(sender, e); });
        }

        private void ClusteringComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClusteringComboBox.Items.Count > 0 && ClusteringComboBox.SelectedIndex >= 0)
            {
                if (PRESAVE) ApplySettings();
                List<string> clustering_out = (List<string>)ClusteringComboBox.Tag;
                if (clustering_out != null)
                {
                    byte[] VecFile = null;
                    ClusteringPicBox.Image = DrawClustering(ref VecFile, clustering_out[ClusteringComboBox.SelectedIndex], CLUSTERING_FONT_SIZE, 10, 30, CLUSTERING_LINE_SEP, ClusteringPicBox.Width, ClusteringPicBox.Height, 20, 0, false, false, true);
                    ClusteringPicBox.Tag = VecFile;
                }
                else ClusteringPicBox.Image = null;
                ClusteringPicBox.Height = ClusteringPicBox.Image != null ? ClusteringPicBox.Image.Height : 50;
            }
        }

        #endregion

        #endregion
    }
}
