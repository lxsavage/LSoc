interface Post {
  postId: number;
  authorId: string;
  authorName: string;
  content: string;
  dateCreate: Date;
}

interface Comment {
  postId: number;
  commentId: number;
  author: string;
  content: string;
  dateCreate: Date;
}
