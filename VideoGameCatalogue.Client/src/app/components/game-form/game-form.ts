import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { VideoGameService } from '../../services/video-game';
import { VideoGame } from '../../models/video-game.model';

@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './game-form.html',
})
export class GameForm implements OnInit {
  game: VideoGame = {
    id: 0,
    title: '',
    genre: '',
    platform: '',
    releaseDate: '',
    price: 0,
    rating: 0,
    description: null
  };

  isEditMode = false;
  errorMessage: string | null = null;

constructor(
    private gameService: VideoGameService,
    private route: ActivatedRoute,
    private router: Router,
    private cdr: ChangeDetectorRef
) {}

  ngOnInit(): void {
    // Check if there's an id in the route to determine edit vs create 
    const id = this.route.snapshot.paramMap.get('id');

   if (id) {
    this.isEditMode = true;
    this.gameService.getById(+id).subscribe({
        next: (data) => {
                          this.game = data;
                          this.game.releaseDate = data.releaseDate.substring(0, 10);
                          this.cdr.detectChanges();
                      },
        error: () => this.errorMessage = 'Game not found.'
    });
}
  }

  onSubmit(): void {
    const action = this.isEditMode
      ? this.gameService.update(this.game)
      : this.gameService.create(this.game);

    action.subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => {
        this.errorMessage = err.error || 'Something went wrong.';
        this.cdr.detectChanges();
      }
    });
}
}