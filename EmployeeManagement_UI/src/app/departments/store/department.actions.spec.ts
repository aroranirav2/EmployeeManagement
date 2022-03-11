import * as fromDepartment from './department.actions';

describe('getDepartments', () => {
  it('should return an action', () => {
    expect(fromDepartment.getDepartments().type).toBe('[Department] Get Departments');
  });
});
