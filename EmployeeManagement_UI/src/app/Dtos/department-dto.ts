import { Guid } from "guid-typescript";
import { EmployeeDto } from "./employee-dto";

export class DepartmentDto {
    departmentId: Guid;
    departmentName: string;
    employees: EmployeeDto[];
}