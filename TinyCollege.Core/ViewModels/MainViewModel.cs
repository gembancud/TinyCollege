using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MvvmCross.ViewModels;
using TinyCollege.Data.Interfaces;
using TinyCollege.Data.Models;
using TinyCollege.Service.Services;

namespace TinyCollege.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
            _AddServices();
            _Initialize();
            _AddCommands();
        }

        private void _AddServices()
        {
            _studentService = new StudentService();
        }

        private void _Initialize()
        {
            var students = _studentService.GetStudents().ToList();
            Students = new ObservableCollection<IStudent>(students);
        }

        private void _AddCommands()
        {
        }

        public ObservableCollection<IStudent> Students { get; set; }
        private StudentService _studentService;
    }
}