import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Component } from '@angular/core';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'home', component: Home },
];
