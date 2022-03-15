import { Guid } from "guid-typescript";
import { Employee } from "src/app/employees/models/employee.model";

export interface Department {
    departmentId: Guid;
    departmentName: string;
    employees: Employee[];
}