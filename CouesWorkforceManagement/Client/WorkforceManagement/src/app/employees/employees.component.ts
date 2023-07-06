import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee.model';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];
  displayedColumns: string[] = ['id', 'firstName', 'lastName', 'position', 'isHR', 'phone', 'address', 'password'];


  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEmployees().subscribe(employees => {
      this.employees = employees;
    });
  }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>('https://localhost:44367/api/employees');
  }
}
