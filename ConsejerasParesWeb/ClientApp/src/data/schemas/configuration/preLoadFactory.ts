import { ConfigLoaderService } from "src/data/services/config-loader.service";

export function PreloadFactory(configService: ConfigLoaderService) {
  return () => configService.initialize();
}
