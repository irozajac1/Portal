import { CommentDetail } from "./comment-detail.model";

export class MessageDetail {
  public MessageId?: number;
  public TextMessage: string;
  public CurrentDate: Date;
  public ListOfComments: CommentDetail[];
  public Email: string;
  public IsApproved: boolean;
  public Group: string;
  public IsDeleted: boolean;
  public Attachments: AttachmentList[];
  public LikeCounter?: number;
  public UserLikeList?: UserLike[];
  // public fileUpload: File;
}

export class LikeRequest {
  public MessageId: number;
  public Email: string;
}

export class Document {
  public DocumentId: number;
  public Time: Date;
  public Title: string;
  public Attachment: AttachmentList;
};

export class AttachmentList {
  AttachmentId: number;
  AttachmentFileName: string;
  AttachmentFileReference: string;
}

export class Employee {
  public EmployeeId?: number;
  public FirstName: string;
  public LastName: string;
  public Email: string;
  public Telephone?: string;
  public Photo: AttachmentList;
}
export class UserLike {
  public LikeId: number;
  public Email: string;
  public IsLiked: boolean;
}
