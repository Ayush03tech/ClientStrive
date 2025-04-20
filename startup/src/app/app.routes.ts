import { Routes } from '@angular/router';
import { MasterComponent } from './components/master/master.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { ClientComponent } from './components/client/client.component';
import { ClientProjectComponent } from './components/client-project/client-project.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'master',
        pathMatch: 'full'
    },
    {
        path: 'master',
        component: MasterComponent

    },
    {
        path: 'employee',
        component: EmployeeComponent,
    },
    {
        path: 'client',
        component: ClientComponent

    },
    {
        path: 'client-project',
        component: ClientProjectComponent

    },
    {
        path: 'add-employee',
        component: AddEmployeeComponent
    }
];
