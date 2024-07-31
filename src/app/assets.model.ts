export interface Asset {
  id: string; // ID of the asset
  name: string; // Name of the asset
  symbolUrl: string; // Symbol URL of the asset
  marketCap: number; // Market capitalization of the asset
  description: string; // Description of the asset
  website: string; // Website of the asset
  launchDate: Date; // Launch date of the asset
  blockchainId: number; // Blockchain ID of the asset
  createDate: Date; // Creation date of the asset
  isDeleted: boolean; // Is the asset deleted?
}