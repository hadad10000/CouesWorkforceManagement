import { Component } from '@angular/core';
import { Employee } from '../Models/employee.model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  //employee: Employee = new Employee();
  employee: Employee = {
    id: 0,
    first_name: '',
    last_name: '',
    position: '',
    is_hr: false,
    phone: '',
    address: '',
    password: ''
  };

  constructor(private employeeService: EmployeeService) { }

  submitForm() {
    this.employeeService.addEmployee(this.employee).subscribe(() => {
      // Reset the form after successful submission
      //this.employee = new Employee();
    });
  }
}
