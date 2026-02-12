import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VideoGame } from '../models/video-game.model';

@Injectable({
  providedIn: 'root'
})
export class VideoGameService {
  // Base URL pointing to local host API
  private apiUrl = 'http://localhost:5151/api/videogames';

  constructor(private http: HttpClient) {}

  // GET: api/videogames
  getAll(): Observable<VideoGame[]> {
    return this.http.get<VideoGame[]>(this.apiUrl);
  }

  // GET: api/videogames/id
  getById(id: number): Observable<VideoGame> {
    return this.http.get<VideoGame>(`${this.apiUrl}/${id}`);
  }

  // POST: api/videogames
  create(game: VideoGame): Observable<VideoGame> {
    return this.http.post<VideoGame>(this.apiUrl, game);
  }

  // PUT: api/videogames/id
  update(game: VideoGame): Observable<VideoGame> {
    return this.http.put<VideoGame>(`${this.apiUrl}/${game.id}`, game);
  }
}