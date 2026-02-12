// TypeScript interface to match back-end VideoGame model
export interface VideoGame {
  id: number;
  title: string;
  genre: string;
  platform: string;
  releaseDate: string;
  price: number;
  rating: number;
  description: string | null;
}