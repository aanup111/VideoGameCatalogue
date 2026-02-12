import { Routes } from '@angular/router';
import { GameList } from './components/game-list/game-list';
import { GameForm } from './components/game-form/game-form';

export const routes: Routes = [
  { path: '', component: GameList },
  { path: 'create', component: GameForm },
  { path: 'edit/:id', component: GameForm },
  { path: '**', redirectTo: '' }
];