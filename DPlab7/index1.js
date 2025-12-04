const EmployeeStatus = {
    ACTIVE: "ACTIVE",
    ON_LEAVE: "ON_LEAVE",
    FIRED: "FIRED"
};

class FieldMaskBool {
    constructor(id, name, salary, department, status) {
        this.id = id;
        this.name = name;
        this.salary = salary;
        this.department = department;
        this.status = status;
    }
}

const FieldMask = {
    ID: 1 << 0,          // 00001
    NAME: 1 << 1,        // 00010
    SALARY: 1 << 2,      // 00100
    DEPARTMENT: 1 << 3,  // 01000
    STATUS: 1 << 4,      // 10000
    ALL: (1 << 5) - 1    // 11111
};

class Employee {
    constructor(id, name, salary, department, status) {
        this.id = id;               // int
        this.name = name;           // string
        this.salary = salary;       // float
        this.department = department;// string
        this.status = status;       // enum
    }

    copyFrom(other, mask) {
        if (mask & FieldMask.ID) this.id = other.id;
        if (mask & FieldMask.NAME) this.name = other.name;
        if (mask & FieldMask.SALARY) this.salary = other.salary;
        if (mask & FieldMask.DEPARTMENT) this.department = other.department;
        if (mask & FieldMask.STATUS) this.status = other.status;
    }
}

class EmployeeDatabase {
    constructor() {
        this.employees = [];
    }

    addEmployee(e) {
        this.employees.push(e);
    }

    findByName(name) {
        return this.employees.filter(e => e.name === name);
    }


    isEqualByMask(a, b, mask) {
        if (mask & FieldMask.ID && a.id !== b.id) return false;
        if (mask & FieldMask.NAME && a.name !== b.name) return false;
        if (mask & FieldMask.SALARY && a.salary !== b.salary) return false;
        if (mask & FieldMask.DEPARTMENT && a.department !== b.department) return false;
        if (mask & FieldMask.STATUS && a.status !== b.status) return false;
        return true;
    }

    /**
     * 
     * @param {FieldMask} mask 
     * @returns 
     */
    mergeByMask(mask) {
        const merged = [];
        const seen = new Set();

        for (let i = 0; i < this.employees.length; i++) {
            if (seen.has(i)) continue;

            let group = [this.employees[i]];
            for (let j = i + 1; j < this.employees.length; j++) {
                if (this.isEqualByMask(this.employees[i], this.employees[j], mask)) {
                    group.push(this.employees[j]);
                    seen.add(j);
                }
            }
            merged.push(group);
        }

        return merged;
    }

    static printWithMask(employees, mask) {
        for (const e of employees) {
            let output = {};
            if (mask & FieldMask.ID) output.id = e.id;
            if (mask & FieldMask.NAME) output.name = e.name;
            if (mask & FieldMask.SALARY) output.salary = e.salary;
            if (mask & FieldMask.DEPARTMENT) output.department = e.department;
            if (mask & FieldMask.STATUS) output.status = e.status;
            console.log(output);
        }
    }
}

const db = new EmployeeDatabase();

db.addEmployee(new Employee(1, "Nikita", 3000.5, "IT", EmployeeStatus.ACTIVE));
db.addEmployee(new Employee(2, "Stasik", 2500.0, "HR", EmployeeStatus.ON_LEAVE));
db.addEmployee(new Employee(3, "Nikita", 3000.5, "IT", EmployeeStatus.ACTIVE));
db.addEmployee(new Employee(4, "Sergo", 4000.0, "Finance", EmployeeStatus.FIRED));

console.log("\nПоиск по имени 'Nikita':");
EmployeeDatabase.printWithMask(db.findByName("Nikita"), FieldMask.ALL);

const mergedByName = db.mergeByMask(FieldMask.NAME);
console.log("\nГруппы по NAME:");
for (let group of mergedByName) {
    EmployeeDatabase.printWithMask(group, FieldMask.ALL);
    console.log("---");
}

console.log("\nДо копирования:");
EmployeeDatabase.printWithMask([db.employees[1]], FieldMask.ALL);

db.employees[1].copyFrom(db.employees[0], FieldMask.DEPARTMENT | FieldMask.SALARY);

console.log("После копирования (Stasik ← Nikita по DEPARTMENT+SALARY):");
EmployeeDatabase.printWithMask([db.employees[1]], FieldMask.ALL);
