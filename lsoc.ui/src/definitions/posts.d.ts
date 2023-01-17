interface Post {
  postId: number;
  author: string;
  content: string;
  likes: number;
  dislikes: number;
  dateCreate: Date;
}

interface Comment {
  postId: number;
  commentId: number;
  author: string;
  content: string;
  dateCreate: Date;
}
