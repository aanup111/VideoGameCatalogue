import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { VideoGameService } from '../../services/video-game';
import { VideoGame } from '../../models/video-game.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-game-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './game-list.html',
})
export class GameList implements OnInit {
  games: VideoGame[] = [];

  constructor(private gameService: VideoGameService) {}

  // Runs on component load
  ngOnInit(): void {
    this.gameService.getAll().subscribe({
      next: (data) => this.games = data,
      error: (err) => console.error('Failed to load games', err)
    });
  }
}