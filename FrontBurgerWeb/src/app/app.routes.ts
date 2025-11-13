import { Routes } from '@angular/router';
import { Dashboard } from './dashboard/dashboard';
import { hash } from 'crypto';


export const routes: Routes = [
    { path: '', component: Dashboard }
];
